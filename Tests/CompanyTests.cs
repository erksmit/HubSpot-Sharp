using HubSpot_Sharp.CRM.Object.Company;

namespace Tests
{
    [TestClass]
    public class CompanyTests : CrmTestFixture<Company>
    {
        protected override Company SampleObject => new ()
        {
            Name = "Cool test company",
            Domain = "testDomain.com"
        };

        protected override void UpdateObject(Company company) => company.Name = "Updated test company";

        protected override List<Company> SampleList => new ()
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

        protected override bool IsEqual(Company left, Company right) => left.Id == right.Id && left.Name == right.Name;
    }
}
