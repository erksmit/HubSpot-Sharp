using System.Runtime.Serialization;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// Contains information about a OAuth token
    /// </summary>
    [DataContract]
    public class OAuthTokenInformation
    {
        /// <summary>
        /// Gets or sets the token the information is about
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Gets or sets the email of the user that authenticated this token
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the hub domain.
        /// </summary>
        [DataMember(Name = "hub_domain")]
        public string HubDomain { get; set; }

        /// <summary>
        /// Gets or sets the scopes that the app has access to.
        /// </summary>
        public IList<string> Scopes { get; set; }

        /// <summary>
        /// Gets or sets the scope to scope group pks.
        /// </summary>
        [DataMember(Name = "scope_to_scope_group_pks")]
        public IList<long> ScopeToScopeGroupPks { get; set; }

        /// <summary>
        /// Gets or sets the scopes that are part of the trail the user is using.
        /// </summary>
        [DataMember(Name = "trail_scopes")]
        public IList<string> TrailScopes { get; set; }

        /// <summary>
        /// Gets or sets the trail scopes to scope group pks.
        /// </summary>
        [DataMember(Name = "trail_scope_to_scope_group_pks")]
        public IList<long> TrailScopeToScopeGroupPks { get; set; }

        /// <summary>
        /// Gets or sets the hub id of the application.
        /// </summary>
        [DataMember(Name = "hub_id")]
        public long HubId { get; set; }

        /// <summary>
        /// Gets or sets the application id.
        /// </summary>
        [DataMember(Name = "app_id")]
        public long AppId { get; set; }

        /// <summary>
        /// Gets or sets the amount of seconds until the token expires.
        /// </summary>
        [DataMember(Name = "expires_in")]
        public int ExpiresIn { get; set; }

        /// <summary>
        /// Gets or sets the id of the user the token belongs to.
        /// </summary>
        [DataMember(Name = "user_id")]
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the type of the token.
        /// </summary>
        [DataMember(Name = "token_type")]
        public string TokenType { get; set; }
    }
}
