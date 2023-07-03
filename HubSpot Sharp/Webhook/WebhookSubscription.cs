using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    [DataContract]
    public class WebhookSubscription : HubSpotObject
    {
        public string EventType { get; set; }

        public string PropertyName { get; set; }

        public bool Active { get; set; }
    }
}
