using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    [DataContract]
    public class WebhookThrottling
    {
        [DataMember]
        public int MaxConcurrentRequests { get; set; }

        [DataMember]
        public string Period { get; set; }
    }
}
