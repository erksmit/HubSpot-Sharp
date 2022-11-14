namespace Tests
{
    using System.Net;

    using HubSpot_Sharp.CRM.Company;
    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    [TestClass]
    public class CompanyTests
    {
        private readonly Company sampleCompany = new()
        {
           Name = "Cool test company",
           Domain = "testDomain.com"
        };
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
        private readonly CompanyApi api = Config.Api.Crm.Company;

        [TestMethod]
        public void Create()
        {
            Company createdCompany = null!;
            try
            {
                createdCompany = api.Create(sampleCompany);
            }
            catch (HubSpotException e)
            {
                Assert.Fail("Failed to create company: {0}", e.Contents.Message);
            }

            try
            {
                api.Archive((long)createdCompany.Id!);
            }
            catch(HubSpotException e)
            {
                Assert.Fail("Failed to delete company: {0}", e.Contents.Message);
            }
        }

        [TestMethod]
        public void Delete()
        {
            Company createdCompany = api.Create(sampleCompany);

            api.Archive((long)createdCompany.Id!);


            try
            {
                Company retrieved = api.Read<Company>((long)createdCompany.Id!);
                Assert.Fail("Retrieved company that was deleted");
            }
            catch (HubSpotException e)
            {
                Assert.AreEqual(HttpStatusCode.NotFound, e.StatusCode);
            }
        }

        [TestMethod]
        public void Update()
        {
            const string UpdatedName = "Cool updated test company";
            const string UpdatedDomain = "updatedDomain.com";

            Company createdCompany = api.Create(sampleCompany);

            createdCompany.Name = UpdatedName;
            createdCompany.Domain = UpdatedDomain;
            long id = (long)createdCompany.Id!;

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

        [TestMethod]
        public void BatchCreateAndDelete()
        { 
            var results = api.CreateBatch(sampleCompanyList).Results;
            
            var options = new ListInputs<IdInput>(results.Select(c => new IdInput(c.Id.ToString()!)).ToList());

            api.ArchiveBatch(options);

            // verify they are all deleted
            foreach (var result in results)
            {
                try
                {
                    Company retrieved = api.Read<Company>((long)result.Id!);
                    Assert.Fail("Retrieved company that was deleted");
                }
                catch (HubSpotException e)
                {
                    Assert.AreEqual(HttpStatusCode.NotFound, e.StatusCode);
                }
            }
        }

        [TestMethod]
        public void BatchUpdate()
        {
            var createResult = api.CreateBatch(sampleCompanyList);
            var createdCompanies = PropertyBag<Company>.UnpackMany(createResult.Results);

            foreach (var company in createdCompanies)
                company.Name += " updated";

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
                var cleanup = new ListInputs<IdInput>(updatedCompanies.Select(c => new IdInput(c.Id.ToString()!)).ToList());
                api.ArchiveBatch(cleanup);
            }
        }

        [TestMethod]
        public void Search()
        {
            var results = api.CreateBatch(sampleCompanyList).Results;
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
                                PropertyName = "name",
                                Operator = SearchOperator.In,
                                Values = sampleCompanyList.Select(c => c.Name).ToList()
                            }
                        }
                    }
                }
            };
            var searchResults = api.Search<Company>(options);

            try
            {
                foreach (var company in PropertyBag<Company>.UnpackMany(searchResults.Results))
                {
                    Assert.IsTrue(sampleCompanyList.Any(c => c.Name == company.Name));
                }
            }
            finally
            {
                var cleanup = new ListInputs<IdInput>(results.Select(c => new IdInput(c.Id.ToString()!)).ToList());
                api.ArchiveBatch(cleanup);
            }
        }

        [TestMethod]
        public void GetByProperties()
        {
            var createResults = api.CreateBatch(sampleCompanyList).Results;
            List<IdInput> ids = createResults.Select(c => new IdInput(c.Id.ToString()!)).ToList();
            var options = new SelectByPropertiesOptions
            {
                IdProperty = "domain",
                Inputs = ids,
                PropertiesToRead = new List<string> {"domain", "name"}
            };
            var result = api.ReadByProperties<Company>(options);
            foreach (var company in PropertyBag<Company>.UnpackMany(result.Results))
            {
                Assert.IsTrue(sampleCompanyList.Any(c => c.Name == company.Name));
            }
            
            var cleanup = new ListInputs<IdInput>(createResults.Select(c => new IdInput(c.Id.ToString()!)).ToList());
            api.ArchiveBatch(cleanup);
        }
    }
}