// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenExchangeResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The response for a token exchange request.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The response for a token exchange request.
    /// </summary>
    [DataContract]
    public class TokenExchangeResponse
    {
        [JsonConstructor]
        // ReSharper disable once StyleCop.SA1600
        internal TokenExchangeResponse(string refreshToken, string accessToken, long expiresIn)
        {
            RefreshToken = refreshToken;
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
        }

        /// <summary>
        /// Gets the refresh token that can be used to request an access token
        /// </summary>
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; }

        /// <summary>
        /// Gets the access token that can be used to authenticate for HubSpot requests.
        /// </summary>
        [DataMember(Name = "access_token")]
        public string AccessToken { get; }

        /// <summary>
        /// Gets the time in seconds until the access token expires
        /// </summary>
        [DataMember(Name = "expires_in")]
        public long ExpiresIn { get; }
    }
}