// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PrivateTokenInfoOptions.cs" company="">
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
        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateTokenInfoOptions"/> class.
        /// </summary>
        /// <param name="token">
        /// The token.
        /// </param>
        public PrivateTokenInfoOptions(string token)
        {
            Token = token;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrivateTokenInfoOptions"/> class.
        /// </summary>
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