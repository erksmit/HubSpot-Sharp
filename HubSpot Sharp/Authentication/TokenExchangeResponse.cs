// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenExchangeResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The response for a token exchange request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The response for a token exchange request.
    /// </summary>
    [DataContract]
    public class TokenExchangeResponse
    {
        /// <summary>
        /// Gets or sets the refresh token that can be used to request an access token
        /// </summary>
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the access token that can be used to authenticate for HubSpot requests.
        /// </summary>
        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the time in seconds until the access token expires
        /// </summary>
        [DataMember(Name = "expires_in")]
        public long ExpiresIn { get; set; }
    }
}