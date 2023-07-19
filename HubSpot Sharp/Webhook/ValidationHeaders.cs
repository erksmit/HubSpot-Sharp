// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidationHeaders.cs" company="">
//   
// </copyright>
// <summary>
//   The validation information v 3.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Webhook
{
    /// <summary>
    /// The validation information v 3.
    /// </summary>
    [DataContract]
    public class ValidationInformationV3
    {
        /// <summary>
        /// Gets or sets the signature.
        /// </summary>
        [DataMember]
        public string Signature { get; set; }

        /// <summary>
        /// Gets or sets the time stamp.
        /// </summary>
        [DataMember]
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        [DataMember]
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the uri.
        /// </summary>
        [DataMember]
        public string Uri { get; set; }

        /// <summary>
        /// Gets or sets the body.
        /// </summary>
        [DataMember]
        public string Body { get; set; }
    }
}