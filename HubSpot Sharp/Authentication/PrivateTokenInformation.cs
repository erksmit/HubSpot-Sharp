// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenInformation.cs" company="">
//   
// </copyright>
// <summary>
//   The token information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// Contains information about a private access token.
    /// </summary>
    [DataContract]
    public class PrivateTokenInformation
    {
        /// <summary>
        /// Gets or sets the user id.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the hub id.
        /// </summary>
        public long HubId { get; set; }

        /// <summary>
        /// Gets or sets the app id.
        /// </summary>
        public long AppId { get; set; }

        /// <summary>
        /// Gets or sets the scopes that the application has access to.
        /// </summary>
        public IList<string> Scopes { get; set; }
    }
}