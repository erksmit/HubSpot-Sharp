using System.Net;

using HubSpot_Sharp.CRM;
using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;
using HubSpot_Sharp.Search;

namespace Tests
{
    public class CrmTestApi<T> : CrmContentApi<T> where T : HubSpotObject
    {
        public CrmTestApi()
            : base(Config.Client)
        {

        }
    }

    [TestClass]
    public abstract class CrmTestFixture<T> where T : HubSpotObject
    {
        private CrmTestApi<T> api;

        private string objectName;

        public CrmTestFixture()
        {
            api = new CrmTestApi<T>();
            objectName = typeof(T).Name;
        }

        protected abstract T SampleObject { get; }

        protected abstract void UpdateObject(T obj);

        protected abstract List<T> SampleList { get; }

        protected abstract bool IsEqual(T left, T right);


        [TestMethod]
        public async Task Create()
        {
            T? createdObject = null;
            try
            {
                createdObject = await api.Create(SampleObject);
            }
            finally
            {
                if (createdObject?.Id != null)
                {
                    await api.Archive((long)createdObject.Id);
                }
            }
        }

        [TestMethod]
        public async Task Read()
        {
            T createdObject = await api.Create(SampleObject);
            try
            {
                T readObject = await api.Read<T>((long)createdObject.Id);
                Assert.IsTrue(IsEqual(readObject, createdObject), $"Read {objectName} was not equal to created object");
            }
            finally
            {
                await api.Archive((long)createdObject.Id);
            }
        }

        [TestMethod]
        public async Task List()
        {
            var createdObjects = (await api.CreateBatch(SampleList)).GetResults();
            List<T> foundObjects = new List<T>();
            try
            {
                bool done;
                string? after = null;
                do
                {
                    var result = await api.List<T>(after: after);
                    if (result.Paging != null)
                    {
                        after = result.Paging.Next.After;
                        done = false;
                    }
                    else
                    {
                        done = true;
                    }

                    var objects = result.GetResults();
                    foundObjects.AddRange(objects.Where(company => createdObjects.Any(c => c.Id == company.Id)));

                    if (foundObjects.Count == createdObjects.Count)
                    {
                        done = true;
                    }
                } 
                while (!done);

                if (foundObjects.Count != createdObjects.Count)
                {
                    Assert.Fail($"Listing did not find all {objectName}s");
                }
            }
            finally
            {
                await api.ArchiveBatch(createdObjects);
            }
        }
        
        [TestMethod]
        public async Task Update()
        {
            T createdObject = await api.Create(SampleObject);
            if (createdObject.Id == null)
            {
                Assert.Fail("Created company did not have an id");
            }

            UpdateObject(createdObject);

            T updatedObject = await api.Update(createdObject);
            try
            {
                Assert.IsTrue(IsEqual(updatedObject, createdObject), $"{objectName}s are not equal after update.");
            }
            finally
            {
                await api.Archive((long)createdObject.Id);
            }
        }

        [TestMethod]
        public async Task Delete()
        {
            T createdObject = await api.Create(SampleObject);

            if (createdObject.Id == null)
            {
                Assert.Fail($"Retrieved  {objectName}  that should have been deleted");
            }

            await api.Archive((long)createdObject.Id);

            try
            {
                await api.Read<T>((long)createdObject.Id);
                Assert.Fail($"Retrieved {objectName} that should have been deleted");
            }
            catch (HubSpotException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.StatusCode);
            }
        }
        
        [TestMethod]
        public async Task BatchCreateAndDelete()
        {
            var results = (await api.CreateBatch(SampleList)).GetResults();

            var options = new ListInputs<IdObject>(IdObject.FromEnumerable(results));

            await api.ArchiveBatch(options);

            // verify they are all deleted
            foreach (var result in results)
            {
                try
                {
                    if (result.Id == null)
                    {
                        Assert.Fail($"Retrieved  {objectName}  that should have been deleted");
                    }

                    await api.Read<T>((long)result.Id);
                    Assert.Fail($"Retrieved {objectName} that should have been deleted");
                }
                catch (HubSpotException e)
                {
                    Assert.AreEqual(HttpStatusCode.NotFound, e.StatusCode);
                }
            }
        }

        [TestMethod]
        public async Task GetByProperties()
        {
            var createResults = (await api.CreateBatch(SampleList)).GetResults();
            List<IdObject> ids = IdObject.FromEnumerable(createResults);

            var options = new SelectByPropertiesOptions
            {
                Inputs = ids,
            };
            try
            {
                var result = await api.ReadByProperties<T>(options);
                foreach (var obj in PropertyBag<T>.UnpackMany(result.Results))
                {
                    Assert.IsTrue(createResults.Any(o => IsEqual(o, obj)), $"Retrieved {objectName} does not match expected values.");
                }
            }
            finally
            {
                await api.ArchiveBatch(new ListInputs<IdObject>(ids));
            }

        }

        [TestMethod]
        public async Task BatchUpdate()
        {
            var createdObjects = (await api.CreateBatch(SampleList)).GetResults();
            foreach (var company in createdObjects)
            {
                UpdateObject(company);
            }

            var updatedObjects = (await api.UpdateBatch(createdObjects)).GetResults();
            try
            {
                foreach (var result in updatedObjects)
                {
                    Assert.IsTrue(createdObjects.Any(o => IsEqual(result, o)), $"{objectName} did not update as expected.");
                }
            }
            finally
            {
                var cleanup = new ListInputs<IdObject>(IdObject.FromEnumerable(updatedObjects));
                await api.ArchiveBatch(cleanup);
            }
        }

        [TestMethod]
        [TestCategory("Slow")]
        public async Task Search()
        {
            var createResults = (await api.CreateBatch(SampleList)).GetResults();
            var options = new SearchOptions
            {
                FilterGroups = new List<FilterGroup>
                {
                    new ()
                    {
                        Filters = new List<Filter>
                        {
                            new ()
                            {
                                PropertyName = "hs_object_id",
                                Operator = SearchOperator.In,
                                Values = createResults.Select(c => c.Id.ToString()).ToList()
                            }
                        }
                    }
                },
                Limit = 100
            };

            // lets wait 20 seconds for HubSpot to process the creation
            Thread.Sleep(20000);
            var results = (await api.Search<T>(options)).GetResults();
            try
            {
                foreach (var obj in results)
                {
                    Assert.IsTrue(
                        createResults.Any(c => IsEqual(c, obj)),
                        $"Search result included {objectName}s that were not supposed to be found.");
                }

                foreach (var sampleObject in createResults)
                {
                    Assert.IsTrue(
                        results.Any(o => IsEqual(o, sampleObject)),
                        $"Search result is missing a {objectName} which was supposed to be found.");
                }
            }
            finally
            {
                var cleanup = new ListInputs<IdObject>(IdObject.FromEnumerable(createResults));
                await api.ArchiveBatch(cleanup);
            }
        }
        
        /// <summary>
        /// Tests creating a <see cref="HubSpotException"/> and checks if the contents serialized.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        [TestMethod]
        public async Task Error()
        {
            try
            {
                // lets do something wrong
                await api.Search<T>(null!);
                Assert.Fail("Search did not fail");
            }
            catch (HubSpotException e)
            {
                Console.WriteLine(e.Contents?.Message);
                Assert.IsNotNull(e.Contents?.Message, "HubSpot error did not deserialize correctly.");
            }
        }
    }
}
