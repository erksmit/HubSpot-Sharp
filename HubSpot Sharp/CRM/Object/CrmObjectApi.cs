// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmObjectApi.cs" company="">
//   
// </copyright>
// <summary>
//   The crm object api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object.Company;
using HubSpot_Sharp.CRM.Object.Contact;
using HubSpot_Sharp.CRM.Object.Custom;
using HubSpot_Sharp.CRM.Object.Deal;
using HubSpot_Sharp.CRM.Object.FeedbackSubmission;
using HubSpot_Sharp.CRM.Object.LineItem;
using HubSpot_Sharp.CRM.Object.Product;
using HubSpot_Sharp.CRM.Object.Quote;
using HubSpot_Sharp.CRM.Object.Tax;
using HubSpot_Sharp.CRM.Object.Ticket;

namespace HubSpot_Sharp.CRM.Object
{
    /// <summary>
    /// The crm object api.
    /// </summary>
    public class CrmObjectApi
    {
        /// <summary>
        /// Gets the company.
        /// </summary>
        public CompanyApi Company { get; }

        /// <summary>
        /// Gets the contact.
        /// </summary>
        public ContactApi Contact { get; }

        /// <summary>
        /// Gets the custom.
        /// </summary>
        public ObjectApi Custom { get; }

        /// <summary>
        /// Gets the deal.
        /// </summary>
        public DealApi Deal { get; }

        /// <summary>
        /// Gets the feedback submission.
        /// </summary>
        public FeedbackSubmissionApi FeedbackSubmission { get; }

        /// <summary>
        /// Gets the line item.
        /// </summary>
        public LineItemApi LineItem { get; }

        /// <summary>
        /// Gets the product.
        /// </summary>
        public ProductApi Product { get; }

        /// <summary>
        /// Gets the quote.
        /// </summary>
        public QuoteApi Quote { get; }

        /// <summary>
        /// Gets the ticket.
        /// </summary>
        public TicketApi Ticket { get; }

        /// <summary>
        /// Gets the schema.
        /// </summary>
        public SchemaApi Schema { get; }

        public TaxApi Tax { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrmObjectApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public CrmObjectApi(HubSpotClient client)
        {
            Company = new CompanyApi(client);
            Contact = new ContactApi(client);
            Deal = new DealApi(client);
            LineItem = new LineItemApi(client);
            Product = new ProductApi(client);
            Ticket = new TicketApi(client);
            Custom = new ObjectApi(client);
            Schema = new SchemaApi(client);
            FeedbackSubmission = new FeedbackSubmissionApi(client);
            Quote = new QuoteApi(client);
            Tax = new TaxApi(client);
        }
    }
}