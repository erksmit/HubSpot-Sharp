using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    [DataContract]
    public class WebhookSubscription : HubSpotObject
    {
        [DataMember]
        public string EventType { get; set; }
        
        [DataMember]
        public string PropertyName { get; set; }
        
        [DataMember]
        public bool Active { get; set; }
    }
}
