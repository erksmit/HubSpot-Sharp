// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GrantRequestOptions.cs" company="">
//   
// </copyright>
// <summary>
//   The grant request form used for OAuth token exchanging.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The grant request form used for OAuth token exchanges.
    /// </summary>
    [DataContract]
    public class GrantRequestOptions
    {
        /// <summary>
        /// Gets or sets the grant request type.
        /// </summary>
        [DataMember(Name = "grant_type")]
        public GrantType GrantType { get; set; }

        /// <summary>
        /// Gets or sets the client id of the app making the request.
        /// </summary>
        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        /// <summary>
        /// Gets or sets the client secret of the app making the request.
        /// </summary>
        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }

        /// <summary>
        /// Gets or sets the redirect uri that was used when the user was authorized.
        /// </summary>
        [DataMember(Name = "redirect_uri")]
        public string RedirectUri { get; set; }

        /// <summary>
        /// Gets or sets the authorization code when requesting a refresh token.
        /// </summary>
        [DataMember(Name = "code")]
        public string AuthorizationCode { get; set; }

        /// <summary>
        /// Gets or sets the refresh token when requesting an access token.
        /// </summary>
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }
    }
}