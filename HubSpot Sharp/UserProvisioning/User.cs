// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="">
//   
// </copyright>
// <summary>
//   The user.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.UserProvisioning
{
    /// <summary>
    /// The user.
    /// </summary>
    [DataContract]
    public class User
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the role id.
        /// </summary>
        [DataMember]
        public string RoleId { get; set; }

        /// <summary>
        /// Gets or sets the primary team id.
        /// </summary>
        [DataMember]
        public string PrimaryTeamId { get; set; }

        /// <summary>
        /// Gets or sets the secondary team ids.
        /// </summary>
        [DataMember]
        public IList<string> SecondaryTeamIds { get; set; }

        /// <summary>
        /// Gets or sets the send welcome email.
        /// </summary>
        [DataMember]
        public bool? SendWelcomeEmail { get; set; }
    }
}