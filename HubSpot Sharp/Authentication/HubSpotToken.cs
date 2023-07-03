// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotToken.cs" company="">
//   
// </copyright>
// <summary>
//   The token object used to authenticate with the HubSpot api
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The token object used to authenticate with the HubSpot api
    /// </summary>
    [DataContract]
    public class HubSpotToken
    {
        /// <summary>
        /// Gets or sets the access token used to authenticate endpoint request.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the refresh token used to refresh the access token.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the authorization token that can be used to exchange for a refresh token.
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// Gets or sets the authentication mode of the application
        /// </summary>
        public HubSpotAuthenticationMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the timestamp that indicates when the access token expires, must be set and checked manually.
        /// </summary>
        public DateTime ExpiresAt { get; set; }
    }
}