// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotAuthenticationMode.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot authentication mode.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The authentication mode of a HubSpot app
    /// </summary>
    public enum HubSpotAuthenticationMode
    {
        /// <summary>
        /// Authentication using an OAuth refresh token
        /// </summary>
        OAuth,

        /// <summary>
        /// Private access token authentication
        /// </summary>
        PrivateAccessToken
    }
}