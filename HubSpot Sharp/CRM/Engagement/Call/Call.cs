// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Call.cs" company="">
//   
// </copyright>
// <summary>
//   The call.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Engagement.Call
{
    /// <summary>
    /// The call.
    /// </summary>
    [DataContract]
    [ApiPathName("calls")]
    [AssociationId("CALL")]
    public class Call : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        [DataMember]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the owner id.
        /// </summary>
        [DataMember]
        public long OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        [DataMember]
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        [DataMember]
        public int Duration { get; set; }

        /// <summary>
        /// Gets or sets the from number.
        /// </summary>
        [DataMember]
        public string FromNumber { get; set; }

        /// <summary>
        /// Gets or sets the to number.
        /// </summary>
        [DataMember]
        public string ToNumber { get; set; }

        /// <summary>
        /// Gets or sets the recording url.
        /// </summary>
        [DataMember]
        public string RecordingUrl { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [DataMember]
        public string Status { get; set; }
    }
}