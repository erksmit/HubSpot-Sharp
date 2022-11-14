using HubSpot_Sharp.CRM.Company;
using HubSpot_Sharp.CRM.Contact;
using HubSpot_Sharp.CRM.Custom;
using HubSpot_Sharp.CRM.Deal;
using HubSpot_Sharp.CRM.LineItem;
using HubSpot_Sharp.CRM.Product;
using HubSpot_Sharp.CRM.Ticket;

namespace HubSpot_Sharp.CRM
{
    public class CrmApi
    {
        public CompanyApi Company { get; }

        public ContactApi Contact { get; }

        public DealApi Deal { get; }

        public LineItemApi LineItem { get; }

        public ProductApi Product { get; }

        public TicketApi Ticket { get; }

        public ObjectApi Custom { get; }

        public SchemaApi Schema { get; }

        public CrmApi(HubSpotClient client)
        {
            Company = new CompanyApi(client);
            Contact = new ContactApi(client);
            Deal = new DealApi(client);
            LineItem = new LineItemApi(client);
            Product = new ProductApi(client);
            Ticket = new TicketApi(client);
            Custom = new ObjectApi(client);
            Schema = new SchemaApi(client);
        }
    }
}
