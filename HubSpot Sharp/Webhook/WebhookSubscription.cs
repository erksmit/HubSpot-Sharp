// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebhookSubscription.cs" company="">
//   
// </copyright>
// <summary>
//   The webhook subscription.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    /// <summary>
    /// The webhook subscription.
    /// </summary>
    [DataContract]
    public class WebhookSubscription : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the event type.
        /// </summary>
        [DataMember]
        public string EventType { get; set; }

        /// <summary>
        /// Gets or sets the property name.
        /// </summary>
        [DataMember]
        public string PropertyName { get; set; }

        /// <summary>
        /// Gets or sets the active.
        /// </summary>
        [DataMember]
        public bool Active { get; set; }
    }
}