// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotExceptionBody.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot exception body.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp
{
    /// <summary>
    /// Represents the information contained in the body of a json error response
    /// </summary>
    [DataContract]
    public class HubSpotExceptionBody
    {
        /// <summary>
        /// Gets or sets the status of the error.
        /// </summary>
        [DataMember]
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the message that HubSpot returned.
        /// </summary>
        [DataMember]
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the category of the error.
        /// </summary>
        [DataMember]
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the sub category of the error.
        /// </summary>
        [DataMember]
        public string SubCategory { get; set; }
    }
}