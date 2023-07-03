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
    /// Tests the company api.
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
        private readonly List<Company> sampleCompanyList = new()
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
        /// The company api.
        /// </summary>
        private readonly CompanyApi api = Config.Api.Crm.Company;

        /// <summary>
        /// Tests creating a company.
        /// </summary>
        [TestMethod]
        public void Create()
        {
            Company? createdCompany = null;
            try
            {
                createdCompany = api.Create(sampleCompany);
            }
            catch (HubSpotException e)
            {
                Assert.Fail("Failed to create company: {0}", e.Contents.Message);
            }
            finally
            {
                if (createdCompany?.Id != null)
                {
                    api.Archive((long)createdCompany.Id);
                }
            }
        }

        /// <summary>
        /// Tests deleting a company.
        /// </summary>
        [TestMethod]
        public void Delete()
        {
            Company createdCompany = api.Create(sampleCompany);

            if (createdCompany.Id == null)
                Assert.Fail("Created company did not have an id");

            api.Archive((long)createdCompany.Id);

            try
            {
                api.Read<Company>((long)createdCompany.Id);
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
        public void Update()
        {
            const string UpdatedName = "Cool updated test company";
            const string UpdatedDomain = "updatedDomain.com";

            Company createdCompany = api.Create(sampleCompany);

            createdCompany.Name = UpdatedName;
            createdCompany.Domain = UpdatedDomain;

            if (createdCompany.Id == null)
                Assert.Fail("Created company did not have an id");
            long id = (long)createdCompany.Id;

            Company updatedCompany = api.Update(createdCompany);
            try
            {
                Assert.AreEqual(UpdatedName, updatedCompany.Name);
                Assert.AreEqual(UpdatedDomain, updatedCompany.Domain);
            }
            finally
            {
                api.Archive(id);
            }
        }

        /// <summary>
        /// Tests batch creation and deletion of companies.
        /// </summary>
        [TestMethod]
        public void BatchCreateAndDelete()
        {
            var results = api.CreateBatch(sampleCompanyList).Results;

            var options = new ListInputs<IdInput>(results.Select(c => new IdInput(c.Id.ToString())).ToList());

            api.ArchiveBatch(options);

            // verify they are all deleted
            foreach (var result in results)
            {
                try
                {
                    if (result.Id == null)
                        Assert.Fail("Created company did not have an id");
                    api.Read<Company>((long)result.Id);
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
        public void BatchUpdate()
        {
            var createResult = api.CreateBatch(sampleCompanyList);
            var createdCompanies = PropertyBag<Company>.UnpackMany(createResult.Results);

            foreach (var company in createdCompanies)
            {
                company.Name += " updated";
            }

            var updateResult = api.UpdateBatch(createdCompanies);

            var updatedCompanies = PropertyBag<Company>.UnpackMany(updateResult.Results);
            try
            {
                foreach (var result in updatedCompanies)
                {
                    Assert.IsTrue(sampleCompanyList.Any(c => (c.Name + " updated") == result.Name));
                }
            }
            finally
            {
                var cleanup =
                    new ListInputs<IdInput>(updatedCompanies.Select(c => new IdInput(c.Id.ToString())).ToList());
                api.ArchiveBatch(cleanup);
            }
        }

        /// <summary>
        /// Tests the search endpoint by searching for some companies.
        /// </summary>
        [TestMethod]
        public void Search()
        {
            var createResults = api.CreateBatch(sampleCompanyList).Results;
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

            // lets wait 5 seconds for HubSpot to process the creation
            Thread.Sleep(5000);
            var searchResults = api.Search<Company>(options);
            var results = PropertyBag<Company>.UnpackMany(searchResults.Results);
            try
            {
                foreach (var company in results)
                {
                    Assert.IsTrue(
                        sampleCompanyList.Any(c => c.Name == company.Name),
                        "Search result included companies that were not supposed to be found.");
                }

                foreach (var sampleCompany in sampleCompanyList)
                {
                    Assert.IsTrue(
                        results.Any(c => c.Name == sampleCompany.Name),
                        "Search result is missing companies that were supposed to be found.");
                }
            }
            finally
            {
                var cleanup =
                    new ListInputs<IdInput>(createResults.Select(c => new IdInput(c.Id.ToString())).ToList());
                api.ArchiveBatch(cleanup);
            }
        }

        /// <summary>
        /// Tests getting some companies by their unique property values.
        /// </summary>
        [TestMethod]
        public void GetByProperties()
        {
            var createResults = api.CreateBatch(sampleCompanyList).Results;
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
            var result = api.ReadByProperties<Company>(options);
            foreach (var company in PropertyBag<Company>.UnpackMany(result.Results))
            {
                Assert.IsTrue(sampleCompanyList.Any(c => c.Name == company.Name));
            }

            var cleanup = new ListInputs<IdInput>(createResults.Select(c => new IdInput(c.Id.ToString() ?? throw new AssertFailedException("Created company did not have an id."))).ToList());
            api.ArchiveBatch(cleanup);
        }

        /// <summary>
        /// Tests creating a <see cref="HubSpotException"/> and checks if the contents serialized.
        /// </summary>
        [TestMethod]
        public void Error()
        {
            try
            {
                // lets do something wrong
                api.Search<Company>(null!);
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