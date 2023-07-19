// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotObject.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot object.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

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
        /// Initializes a new instance of the <see cref="HubSpotObject"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="createdAt">
        /// The created at.
        /// </param>
        /// <param name="lastModified">
        /// The last modified.
        /// </param>
        public HubSpotObject(long? id = null, DateTime? createdAt = null, DateTime? lastModified = null)
        {
            Id = id;
            CreatedAt = createdAt;
            LastModified = lastModified;
        }

        /// <summary>
        /// Gets or sets the id of the object.
        /// </summary>
        [DeserializeOnly]
        public long? Id { get; set; }

        /// <summary>
        /// Gets the timestamp of when the object was created.
        /// </summary>
        [DataMember(Name = "createdate")]
        [DeserializeOnly]
        public DateTime? CreatedAt { get; }

        /// <summary>
        /// Gets the timestamp of when the object was last modified.
        /// </summary>
        [DataMember(Name = "hs_lastmodifieddate")]
        [DeserializeOnly]
        public DateTime? LastModified { get; }
    }
}