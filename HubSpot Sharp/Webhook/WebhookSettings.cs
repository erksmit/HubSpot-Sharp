using System.Runtime.Serialization;

using HubSpot_Sharp.Serialization;

namespace HubSpot_Sharp.Webhook
{
    [DataContract]
    public class WebhookSettings
    {
        [DataMember]
        public string TargetUrl { get; set; }
        
        [DataMember]
        public WebhookThrottling Throttling { get; set; }
        
        [DataMember]
        [DeserializeOnly]
        public DateTime? CreatedAt { get; set; }
        
        [DataMember]
        [DeserializeOnly]
        public DateTime? UpdatedAt { get; set; }
    }
}
