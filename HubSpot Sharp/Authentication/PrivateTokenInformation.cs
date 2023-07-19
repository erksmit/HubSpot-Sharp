// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrivateTokenInformation.cs" company="">
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
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateTokenInformation"/> class.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="hubId">
        /// The hub id.
        /// </param>
        /// <param name="appId">
        /// The app id.
        /// </param>
        /// <param name="scopes">
        /// The scopes.
        /// </param>
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