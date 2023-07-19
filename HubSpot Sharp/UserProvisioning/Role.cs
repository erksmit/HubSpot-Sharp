// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Role.cs" company="">
//   
// </copyright>
// <summary>
//   The role.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    /// <summary>
    /// The role.
    /// </summary>
    [DataContract]
    public class Role
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Role"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        public Role(string id, string name)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [DataMember]
        public string Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [DataMember]
        public string Name { get; }
    }
}