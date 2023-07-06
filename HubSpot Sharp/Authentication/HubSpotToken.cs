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
        [DataMember]
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the refresh token used to refresh the access token.
        /// </summary>
        [DataMember]
        public string RefreshToken { get; set; }

        /// <summary>
        /// Gets or sets the authorization token that can be used to exchange for a refresh token.
        /// </summary>
        [DataMember]
        public string AuthToken { get; set; }

        /// <summary>
        /// Gets or sets the authentication mode of the application
        /// </summary>
        [DataMember]
        public HubSpotAuthenticationMode Mode { get; set; }

        /// <summary>
        /// Gets or sets the timestamp that indicates when the access token expires, must be set and checked manually.
        /// </summary>
        [DataMember]
        public DateTime ExpiresAt { get; set; }
    }
}