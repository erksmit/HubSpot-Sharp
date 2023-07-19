using System.Security.Cryptography;
using System.Text;
using System.Web;

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.Webhook
{
    public class WebhookApi
    {
        public HubSpotClient client;

        public WebhookApi(HubSpotClient client)
        {
            this.client = client;
        }

        public async Task<WebhookSettings> GetSettings(int appId)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            return await client.Execute<WebhookSettings>(path);
        }

        public async Task<WebhookSettings> UpdateSettings(int appId, WebhookSettings settings)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            return await client.Execute<WebhookSettings>(path, HttpMethod.Put, settings);
        }

        public async Task DeleteSettings(int appId)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            await client.Execute(path, HttpMethod.Delete);
        }

        public async Task<ListResult<WebhookSubscription>> GetSubscriptions(int appId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions";
            return await client.Execute<ListResult<WebhookSubscription>>(path);
        }

        public async Task<WebhookSubscription> UpdateSubscription(int appId, WebhookSubscription subscription)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions";
            return await client.Execute<WebhookSubscription>(path, HttpMethod.Post, subscription);
        }

        public async Task<WebhookSubscription> GetSubscription(int appId, int subscriptionId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions/{subscriptionId}";
            return await client.Execute<WebhookSubscription>(path);
        }

        public async Task DeleteSubscription(int appId, int subscriptionId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions/{subscriptionId}";
            await client.Execute(path, HttpMethod.Delete);
        }

        public bool IsV3RequestValid(ValidationInformationV3 headers, string clientSecret)
        {
            if (headers.TimeStamp < DateTime.UtcNow.AddMinutes(-5))
                return false;

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
