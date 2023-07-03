// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GrantTypes.cs" company="">
//   
// </copyright>
// <summary>
//   The grant type of a token exchange request form.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The grant type of a token exchange request form.
    /// </summary>
    [DataContract]
    public enum GrantType
    {
        /// <summary>
        /// Exchange an authorization code for a refresh token and an access token.
        /// </summary>
        [EnumMember(Value = "authorization_code")]
        AuthorizationCode,

        /// <summary>
        /// Exchange a refresh token for an access token.
        /// </summary>
        [EnumMember(Value = "refresh_token")]
        RefreshToken
    }
}