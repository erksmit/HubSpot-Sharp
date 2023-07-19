// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Team.cs" company="">
//   
// </copyright>
// <summary>
//   The team.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    /// <summary>
    /// The team.
    /// </summary>
    [DataContract]
    public class Team
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Team"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="userIds">
        /// The user ids.
        /// </param>
        /// <param name="secondaryUserIds">
        /// The secondary user ids.
        /// </param>
        public Team(string id, string name, IList<string> userIds, IList<string> secondaryUserIds)
        {
            Id = id;
            Name = name;
            UserIds = userIds;
            SecondaryUserIds = secondaryUserIds;
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

        /// <summary>
        /// Gets the user ids.
        /// </summary>
        [DataMember]
        public IList<string> UserIds { get; }

        /// <summary>
        /// Gets the secondary user ids.
        /// </summary>
        [DataMember]
        public IList<string> SecondaryUserIds { get; }
    }
}