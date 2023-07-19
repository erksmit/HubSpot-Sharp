// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotApi.cs" company="">
//   
// </copyright>
// <summary>
//   Provides Api objects for interacting with the HubSpot Api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.AccountActivity;
using HubSpot_Sharp.Authentication;
using HubSpot_Sharp.CRM;
using HubSpot_Sharp.UserProvisioning;
using HubSpot_Sharp.Webhook;

namespace HubSpot_Sharp
{
    /// <summary>
    /// Provides Api objects for interacting with the HubSpot Api.
    /// </summary>
    public class HubSpotApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HubSpotApi"/> class with a <see cref="HubSpotToken"/> private access- or
        /// Oauth token
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public HubSpotApi(HubSpotToken token)
            : this(new HubSpotClient(token))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HubSpotApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public HubSpotApi(HubSpotClient client)
        {
            Authentication = new AuthenticationApi(client);
            Crm = new CrmApi(client);
            Webhook = new WebhookApi(client);
            AccountActivity = new AccountActivityApi(client);
            UserProvisioning = new UserProvisioningApi(client);
        }

        /// <summary>
        /// Gets the authentication api.
        /// </summary>
        public AuthenticationApi Authentication { get; }

        /// <summary>
        /// Gets the CRM api.
        /// </summary>
        public CrmApi Crm { get; }

        /// <summary>
        /// Gets the webhook.
        /// </summary>
        public WebhookApi Webhook { get; }

        /// <summary>
        /// Gets the account activity.
        /// </summary>
        public AccountActivityApi AccountActivity { get; }

        /// <summary>
        /// Gets the user provisioning.
        /// </summary>
        public UserProvisioningApi UserProvisioning { get; }
    }
}