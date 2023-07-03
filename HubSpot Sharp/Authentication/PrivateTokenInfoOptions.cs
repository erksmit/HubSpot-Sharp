// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenInfoOptions.cs" company="">
//   
// </copyright>
// <summary>
//   The request form for getting private access token information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Authentication
{
    /// <summary>
    /// The request form for getting private access token information.
    /// </summary>
    [DataContract]
    public class PrivateTokenInfoOptions
    {
        public PrivateTokenInfoOptions(string token)
        {
            Token = token;
        }

        public PrivateTokenInfoOptions()
        {
        }

        /// <summary>
        /// Gets or sets the private access token to get information about.
        /// </summary>
        [DataMember(Name = "tokenKey")]
        public string Token { get; set; }
    }
}