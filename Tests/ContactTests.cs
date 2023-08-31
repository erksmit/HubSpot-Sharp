using HubSpot_Sharp.CRM.Object.Contact;

namespace Tests
{
    [TestClass]
    public class ContactTests : CrmTestFixture<Contact>
    {
        protected override Contact SampleObject => new ()
        {
            FirstName = "John",
            LastName = "Test"
        };

        protected override void UpdateObject(Contact Contact) => Contact.FirstName = "Updated test Contact";

        protected override List<Contact> SampleList => new ()
        {
            new Contact
            {
                FirstName = "John 1",
                LastName = "Test"
            },
            new Contact
            {
                FirstName = "John 2",
                LastName = "Test"
            },
            new Contact
            {
                FirstName = "John 3",
                LastName = "Test"
            }
        };

        protected override bool IsEqual(Contact left, Contact right) => left.Id == right.Id && left.FirstName == right.FirstName;
    }
}