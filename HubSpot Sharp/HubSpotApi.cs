namespace HubSpot_Sharp
{
    using HubSpot_Sharp.Authentication;
    using HubSpot_Sharp.CRM;

    /// <summary>
    /// Provides Api objects for interacting with the HubSpot Api.
    /// </summary>
    public class HubSpotApi
    {
        public AuthenticationApi Authentication { get; }

        public CrmApi Crm { get; }

        /// <summary>
        /// Creates a new <see cref="HubSpotApi" /> with a <see cref="HubSpotToken" /> private access- or Oauth token
        /// </summary>
        public HubSpotApi(HubSpotToken token) : this(new HubSpotClient(token))
        { }

        public HubSpotApi(HubSpotClient client)
        {
            Authentication = new AuthenticationApi(client);
            Crm = new CrmApi(client);
        }
    }
}