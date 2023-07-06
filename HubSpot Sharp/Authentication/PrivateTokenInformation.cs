// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenInformation.cs" company="">
//   
// </copyright>
// <summary>
//   The token information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// Contains information about a private access token.
    /// </summary>
    [DataContract]
    public class PrivateTokenInformation
    {
        [JsonConstructor]
        // ReSharper disable once StyleCop.SA1600
        internal PrivateTokenInformation(long userId, long hubId, long appId, IList<string> scopes)
        {
            UserId = userId;
            HubId = hubId;
            AppId = appId;
            Scopes = scopes;
        }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        [DataMember]
        public long UserId { get; }

        /// <summary>
        /// Gets the hub id.
        /// </summary>
        [DataMember]
        public long HubId { get; }

        /// <summary>
        /// Gets the app id.
        /// </summary>
        [DataMember]
        public long AppId { get; }

        /// <summary>
        /// Gets the scopes that the application has access to.
        /// </summary>
        [DataMember]
        public IList<string> Scopes { get; }
    }
}