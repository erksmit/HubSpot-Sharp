// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OAuthTokenInformation.cs" company="">
//   
// </copyright>
// <summary>
//   Contains information about a OAuth token
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// Contains information about a OAuth token
    /// </summary>
    [DataContract]
    public class OAuthTokenInformation
    {
        [JsonConstructor]
        // ReSharper disable once StyleCop.SA1600 Type will only be constructed via deserialization.
        internal OAuthTokenInformation(
            string token,
            string user,
            string hubDomain,
            IList<string> scopes,
            IList<long> scopeToScopeGroupPks,
            long hubId,
            long appId,
            int expiresIn,
            long userId,
            string tokenType,
            IList<string>? trailScopes = null,
            IList<long>? trailScopeToScopeGroupPks = null)
        {
            Token = token;
            User = user;
            HubDomain = hubDomain;
            Scopes = scopes;
            ScopeToScopeGroupPks = scopeToScopeGroupPks;
            TrailScopes = trailScopes;
            TrailScopeToScopeGroupPks = trailScopeToScopeGroupPks;
            HubId = hubId;
            AppId = appId;
            ExpiresIn = expiresIn;
            UserId = userId;
            TokenType = tokenType;
        }

        /// <summary>
        /// Gets the token the information is about
        /// </summary>
        [DataMember]
        public string Token { get; }

        /// <summary>
        /// Gets the email of the user that authenticated this token
        /// </summary>
        [DataMember]
        public string User { get; }

        /// <summary>
        /// Gets the hub domain.
        /// </summary>
        [DataMember(Name = "hub_domain")]
        public string HubDomain { get; }

        /// <summary>
        /// Gets the scopes that the app has access to.
        /// </summary>
        public IList<string> Scopes { get; }

        /// <summary>
        /// Gets the scope to scope group pks.
        /// </summary>
        [DataMember(Name = "scope_to_scope_group_pks")]
        public IList<long> ScopeToScopeGroupPks { get; }

        /// <summary>
        /// Gets the scopes that are part of the trail the user is using.
        /// </summary>
        [DataMember(Name = "trail_scopes")]
        public IList<string>? TrailScopes { get; }

        /// <summary>
        /// Gets the trail scopes to scope group pks.
        /// </summary>
        [DataMember(Name = "trail_scope_to_scope_group_pks")]
        public IList<long>? TrailScopeToScopeGroupPks { get; }

        /// <summary>
        /// Gets the hub id of the application.
        /// </summary>
        [DataMember(Name = "hub_id")]
        public long HubId { get; }

        /// <summary>
        /// Gets the application id.
        /// </summary>
        [DataMember(Name = "app_id")]
        public long AppId { get; }

        /// <summary>
        /// Gets the amount of seconds until the token expires.
        /// </summary>
        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; }

        /// <summary>
        /// Gets the id of the user the token belongs to.
        /// </summary>
        [DataMember(Name = "user_id")]
        public long UserId { get; }

        /// <summary>
        /// Gets the type of the token.
        /// </summary>
        [DataMember(Name = "token_type")]
        public string TokenType { get; }
    }
}