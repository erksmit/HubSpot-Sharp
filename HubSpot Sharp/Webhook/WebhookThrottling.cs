using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    [DataContract]
    public class WebhookThrottling
    {
        public int MaxConcurrentRequests { get; set; }

        public string Period { get; set; }
    }
}
