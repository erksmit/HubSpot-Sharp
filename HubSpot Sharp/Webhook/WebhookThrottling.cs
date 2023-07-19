// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebhookThrottling.cs" company="">
//   
// </copyright>
// <summary>
//   The webhook throttling.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    /// <summary>
    /// The webhook throttling.
    /// </summary>
    [DataContract]
    public class WebhookThrottling
    {
        /// <summary>
        /// Gets or sets the max concurrent requests.
        /// </summary>
        [DataMember]
        public int MaxConcurrentRequests { get; set; }

        /// <summary>
        /// Gets or sets the period.
        /// </summary>
        [DataMember]
        public string Period { get; set; }
    }
}