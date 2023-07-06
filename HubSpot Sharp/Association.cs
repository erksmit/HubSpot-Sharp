// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Association.cs" company="">
//   
// </copyright>
// <summary>
//   The association.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp
{
    /// <summary>
    /// An association between two objects in HubSpot.
    /// </summary>
    [DataContract]
    public class Association
    {
        /// <summary>
        /// Gets or sets the id of the association.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the association type name.
        /// </summary>
        [DataMember]
        public string Type { get; set; }
    }
}