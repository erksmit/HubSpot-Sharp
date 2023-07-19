// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WebhookSettings.cs" company="">
//   
// </copyright>
// <summary>
//   The webhook settings.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using HubSpot_Sharp.Serialization;

namespace HubSpot_Sharp.Webhook
{
    /// <summary>
    /// The webhook settings.
    /// </summary>
    [DataContract]
    public class WebhookSettings
    {
        /// <summary>
        /// Gets or sets the target url.
        /// </summary>
        [DataMember]
        public string TargetUrl { get; set; }

        /// <summary>
        /// Gets or sets the throttling.
        /// </summary>
        [DataMember]
        public WebhookThrottling Throttling { get; set; }

        /// <summary>
        /// Gets or sets the created at.
        /// </summary>
        [DataMember]
        [DeserializeOnly]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the updated at.
        /// </summary>
        [DataMember]
        [DeserializeOnly]
        public DateTime? UpdatedAt { get; set; }
    }
}