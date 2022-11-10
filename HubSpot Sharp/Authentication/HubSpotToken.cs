namespace HubSpot_Sharp.Authentication
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    /// The token object used to authenticate with the HubSpot api
    /// </summary>
    [DataContract]
    public class HubSpotToken
    {
        [DataMember(Name = "tokenKey")]
        public string AccessToken { get; set; }

        [IgnoreDataMember]
        public string RefreshToken { get; set; }

        [IgnoreDataMember]
        public string AuthToken { get; set; }

        [IgnoreDataMember]
        public HubSpotAuthenticationMode Mode { get; set; }

        [IgnoreDataMember]
        public DateTime ExpiresIn { get; set; }
    }
}