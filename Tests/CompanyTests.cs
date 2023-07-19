// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyTests.cs" company="">
//   
// </copyright>
// <summary>
//   The company tests.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Net;

using HubSpot_Sharp.CRM.Company;
using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;
using HubSpot_Sharp.Search;

namespace Tests
{
    /// <summary>
    /// Tests the company await api.
    /// </summary>
    [TestClass]
    public class CompanyTests
    {
        /// <summary>
        /// A single sample company.
        /// </summary>
        private readonly Company sampleCompany = new()
        {
            Name = "Cool test company",
            Domain = "testDomain.com"
        };

        /// <summary>
        /// A list of sample companies.
        /// </summary>
        private readonly List<Company> sampleCompanies = new()
        {
            new Company
            {
                Name = "Cool test company",
                Domain = "testDomain.com"
            },
            new Company
            {
                Name = "Cool test company 2",
                Domain = "testDomain.com"
            },
            new Company
            {
                Name = "Cool test company 3",
                Domain = "testDomain.com"
            }
        };

        /// <summary>
        /// The company await api.
        /// </summary>
        private readonly CompanyApi api = Config.Api.Crm.Company;

        /// <summary>
        /// Tests creating a company.
        /// </summary>
        [TestMethod]
        public async Task Create()
        {
            Company? createdCompany = null;
            try
            {
                createdCompany = await api.Create(sampleCompany);
            }
            catch (HubSpotException e)
            {
                Assert.Fail("Failed to create company: {0}", e.Contents?.Message);
            }
            finally
            {
                if (createdCompany?.Id != null)
                { 
                    await api.Archive((long)createdCompany.Id);
                }
            }
        }

        /// <summary>
        /// Tests deleting a company.
        /// </summary>
        [TestMethod]
        public async Task Delete()
        {
            Company createdCompany = await api.Create(sampleCompany);

            if (createdCompany.Id == null)
                Assert.Fail("Created company did not have an id");

            await api.Archive((long)createdCompany.Id);

            try
            {
                await api.Read<Company>((long)createdCompany.Id);
                Assert.Fail("Retrieved company that was deleted");
            }
            catch (HubSpotException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.StatusCode);
            }
        }

        /// <summary>
        /// Tests updating a company's properties.
        /// </summary>
        [TestMethod]
        public async Task Update()
        {
            const string UpdatedName = "Cool updated test company";
            const string UpdatedDomain = "updatedDomain.com";

            Company createdCompany = await api.Create(sampleCompany);

            createdCompany.Name = UpdatedName;
            createdCompany.Domain = UpdatedDomain;

            if (createdCompany.Id == null)
                Assert.Fail("Created company did not have an id");
            long id = (long)createdCompany.Id;

            Company updatedCompany = await api.Update(createdCompany);
            try
            {
                Assert.AreEqual(UpdatedName, updatedCompany.Name);
                Assert.AreEqual(UpdatedDomain, updatedCompany.Domain);
            }
            finally
            {
                await api.Archive(id);
            }
        }

        /// <summary>
        /// Tests batch creation and deletion of companies.
        /// </summary>
        [TestMethod]
        public async Task BatchCreateAndDelete()
        {
            var results = (await api.CreateBatch(sampleCompanies)).GetResults();

            var options = new ListInputs<IdInput>(results.Select(c => new IdInput(c.Id.ToString())).ToList());

            await api.ArchiveBatch(options);

            // verify they are all deleted
            foreach (var result in results)
            {
                try
                {
                    if (result.Id == null)
                        Assert.Fail("Created company did not have an id");
                    await api.Read<Company>((long)result.Id);
                    Assert.Fail("Retrieved company that was deleted");
                }
                catch (HubSpotException e)
                {
                    Assert.AreEqual(HttpStatusCode.NotFound, e.StatusCode);
                }
            }
        }

        /// <summary>
        /// Tests batch updating a company.
        /// </summary>
        [TestMethod]
        public async Task BatchUpdate()
        {
            var createdCompanies = (await api.CreateBatch(sampleCompanies)).GetResults();
            foreach (var company in createdCompanies)
            {
                company.Name += " updated";
            }

            var updatedCompanies = (await api.UpdateBatch(createdCompanies)).GetResults();
            try
            {
                foreach (var result in updatedCompanies)
                {
                    Assert.IsTrue(sampleCompanies.Any(c => (c.Name + " updated") == result.Name), "Company name is not updated as expected");
                }
            }
            finally
            {
                var cleanup =
                    new ListInputs<IdInput>(updatedCompanies.Select(c => new IdInput(c.Id.ToString())).ToList());
                await api.ArchiveBatch(cleanup);
            }
        }

        
        /// <summary>
        /// Tests the search endpoint by searching for some companies.
        /// </summary>
        [TestMethod]
        [TestCategory("Slow")]
        public async Task Search()
        {
            var createResults = (await api.CreateBatch(sampleCompanies)).GetResults();
            var options = new SearchOptions
            {
                FilterGroups = new List<FilterGroup>
                {
                    new()
                    {
                        Filters = new List<Filter>
                        {
                            new()
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
            var results = (await api.Search<Company>(options)).GetResults();
            try
            {
                foreach (var company in results)
                {
                    Assert.IsTrue(
                        sampleCompanies.Any(c => c.Name == company.Name),
                        "Search result included companies that were not supposed to be found.");
                }

                foreach (var sampleCompany in sampleCompanies)
                {
                    Assert.IsTrue(
                        results.Any(c => c.Name == sampleCompany.Name),
                        $"Search result is missing company {sampleCompany.Name} which was supposed to be found.");
                }
            }
            finally
            {
                var cleanup =
                    new ListInputs<IdInput>(createResults.Select(c => new IdInput(c.Id.ToString())).ToList());
                await api.ArchiveBatch(cleanup);
            }
        }
        

        /// <summary>
        /// Tests getting some companies by their unique property values.
        /// </summary>
        [TestMethod]
        public async Task GetByProperties()
        {
            var createResults = (await api.CreateBatch(sampleCompanies)).Results;
            List<IdInput> ids = createResults.Select(c => new IdInput(c.Id.ToString() ?? throw new AssertFailedException("Created company did not have an id."))).ToList();
            var options = new SelectByPropertiesOptions
            {
                IdProperty = "domain",
                Inputs = ids,
                PropertiesToRead = new List<string>
                {
                    "domain",
                    "name"
                }
            };
            var result = await api.ReadByProperties<Company>(options);
            foreach (var company in PropertyBag<Company>.UnpackMany(result.Results))
            {
                Assert.IsTrue(sampleCompanies.Any(c => c.Name == company.Name));
            }

            var cleanup = new ListInputs<IdInput>(createResults.Select(c => new IdInput(c.Id.ToString() ?? throw new AssertFailedException("Created company did not have an id."))).ToList());
            await api.ArchiveBatch(cleanup);
        }

        /// <summary>
        /// Tests creating a <see cref="HubSpotException"/> and checks if the contents serialized.
        /// </summary>
        [TestMethod]
        public async Task Error()
        {
            try
            {
                // lets do something wrong
                await api.Search<Company>(null!);
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