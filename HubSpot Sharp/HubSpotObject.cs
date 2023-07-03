// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotObject.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;
using System.Runtime.Serialization;

using HubSpot_Sharp.Serialization;

namespace HubSpot_Sharp
{
    /// <summary>
    /// Represents an object in the HubSpot CRM.
    /// </summary>
    [DataContract]
    public abstract class HubSpotObject
    {
        /// <summary>
        /// Gets or sets the id of the object.
        /// </summary>
        [DeserializeOnly]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the object was created.
        /// </summary>
        [DataMember(Name = "createdate")]
        [DeserializeOnly]
        public DateTime? Created { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the object was last modified.
        /// </summary>
        [DataMember(Name = "hs_lastmodifieddate")]
        [DeserializeOnly]
        public DateTime? LastModified { get; set; }
    }
}