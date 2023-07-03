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

        public WebhookSettings GetSettings(int appId)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            return client.Execute<WebhookSettings>(path);
        }

        public WebhookSettings UpdateSettings(int appId, WebhookSettings settings)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            return client.Execute<WebhookSettings>(path, HttpMethod.Put, settings);
        }

        public void DeleteSettings(int appId)
        {
            var path = $"/webhooks/v3/{appId}/settings";
            client.Execute(path, HttpMethod.Delete);
        }

        public ListResult<WebhookSubscription> GetSubscriptions(int appId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions";
            return client.Execute<ListResult<WebhookSubscription>>(path);
        }

        public WebhookSubscription UpdateSubScription(int appId, WebhookSubscription subscription)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions";
            return client.Execute<WebhookSubscription>(path, HttpMethod.Post, subscription);
        }

        public WebhookSubscription GetSubscription(int appId, int subscriptionId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions/{subscriptionId}";
            return client.Execute<WebhookSubscription>(path);
        }

        public void DeleteSubscription(int appId, int subscriptionId)
        {
            var path = $"/webhooks/v3/{appId}/subscriptions/{subscriptionId}";
            client.Execute(path, HttpMethod.Delete);
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

            using var sha = new HMACSHA256(secret8Bytes);
            var hashBytes = sha.ComputeHash(bytes8);
            var hashString = Convert.ToBase64String(hashBytes);
            return headers.Signature == hashString;
        }
    }
}
