namespace HubSpot_Sharp
{
    using HubSpot_Sharp.Authentication;
    using HubSpot_Sharp.Company;
    using HubSpot_Sharp.Contact;
    using HubSpot_Sharp.Custom;

    /// <summary>
    /// Provides Api objects for interacting with the HubSpot Api.
    /// </summary>
    public class HubSpotApi
    {
        public AuthenticationApi Authentication { get; }

        public ContactApi Contact { get; }

        public CompanyApi Company { get; }

        public CustomObjectApi Custom { get; }

        public SchemaApi Schema { get; }

        /// <summary>
        /// Creates a new <see cref="HubSpotApi" /> with a <see cref="HubSpotToken" /> private access- or Oauth token
        /// </summary>
        public HubSpotApi(HubSpotToken token)
        {
            var client = new HubSpotClient(token);
            Contact = new ContactApi(client);
            Company = new CompanyApi(client);
            Custom = new CustomObjectApi(client);
            Schema = new SchemaApi(client);
            Authentication = new AuthenticationApi(client);
        }
    }
}