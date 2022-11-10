namespace HubSpot_Sharp.Authentication
{
    using System.Runtime.Serialization;

    [DataContract]
    public class TokenExchangeResponse
    {
        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }

        [DataMember(Name = "access_token")]
        public string AccessToken { get; set; }

        /// <summary>
        /// The time in seconds until the access token expires
        /// </summary>
        [DataMember(Name = "expires_in")]
        public long ExpiresIn { get; set; }
    }
}