using System.Runtime.Serialization;

using HubSpot_Sharp.Serialization;

namespace HubSpot_Sharp.Webhook
{
    [DataContract]
    public class WebhookSettings
    {
        public string TargetUrl { get; set; }

        public WebhookThrottling Throttling { get; set; }

        [DeserializeOnly]
        public DateTime? CreatedAt { get; set; }
        
        [DeserializeOnly]
        public DateTime? UpdatedAt { get; set; }
    }
}
