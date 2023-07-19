// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebhookApi.cs" company="">
//   
// </copyright>
// <summary>
//   The webhook api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Security.Cryptography;
using System.Text;
using System.Web;

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.Webhook
{
    /// <summary>
    /// The webhook api.
    /// </summary>
    public class WebhookApi
    {
        /// <summary>
        /// The client.
        /// </summary>
        public HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebhookApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public WebhookApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The get settings.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<WebhookSettings> GetSettings(int appId)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            return await client.Execute<WebhookSettings>(path);
        }

        /// <summary>
        /// The update settings.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<WebhookSettings> UpdateSettings(int appId, WebhookSettings settings)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            return await client.Execute<WebhookSettings>(path, HttpMethod.Put, settings);
        }

        /// <summary>
        /// The delete settings.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task DeleteSettings(int appId)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            await client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// The get subscriptions.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<WebhookSubscription>> GetSubscriptions(int appId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions";
            return await client.Execute<ListResult<WebhookSubscription>>(path);
        }

        /// <summary>
        /// The update subscription.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <param name="subscription">
        /// The subscription.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<WebhookSubscription> UpdateSubscription(int appId, WebhookSubscription subscription)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions";
            return await client.Execute<WebhookSubscription>(path, HttpMethod.Post, subscription);
        }

        /// <summary>
        /// The get subscription.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <param name="subscriptionId">
        /// The subscription id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<WebhookSubscription> GetSubscription(int appId, int subscriptionId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions/{subscriptionId}";
            return await client.Execute<WebhookSubscription>(path);
        }

        /// <summary>
        /// The delete subscription.
        /// </summary>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <param name="subscriptionId">
        /// The subscription id.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task DeleteSubscription(int appId, int subscriptionId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions/{subscriptionId}";
            await client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// The is v 3 request valid.
        /// </summary>
        /// <param name="headers">
        /// The headers.
        /// </param>
        /// <param name="clientSecret">
        /// The client secret.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsV3RequestValid(ValidationInformationV3 headers, string clientSecret)
        {
            if (headers.TimeStamp < DateTime.UtcNow.AddMinutes(-5))
            {
                return false;
            }

            var decodedUri = HttpUtility.UrlDecode(headers.Uri);
            var utf16 = headers.Method + decodedUri + headers.Body + headers.TimeStamp.Ticks;
            var bytes16 = Encoding.Default.GetBytes(utf16);
            var utf8 = Encoding.UTF8.GetString(bytes16);
            var bytes8 = Encoding.UTF8.GetBytes(utf8);

            var secret16Bytes = Encoding.Default.GetBytes(clientSecret);
            var secretUtf8 = Encoding.UTF8.GetString(secret16Bytes);
            var secret8Bytes = Encoding.UTF8.GetBytes(secretUtf8);

            string hashString;
            using (var sha = new HMACSHA256(secret8Bytes))
            {
                var hashBytes = sha.ComputeHash(bytes8);
                hashString = Convert.ToBase64String(hashBytes);
            }

            return headers.Signature == hashString;
        }
    }
}