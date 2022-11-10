namespace HubSpot_Sharp.Authentication
{
    using System.Runtime.Serialization;

    [DataContract]
    public class GrantRequestForm
    {
        [DataMember(Name = "grant_type")]
        public GrantType GrantType { get; set; }

        [DataMember(Name = "client_id")]
        public string ClientId { get; set; }

        [DataMember(Name = "client_secret")]
        public string ClientSecret { get; set; }

        [DataMember(Name = "redirect_uri")]
        public string RedirectUri { get; set; }

        [DataMember(Name = "code")]
        public string AuthorizationCode { get; set; }

        [DataMember(Name = "refresh_token")]
        public string RefreshToken { get; set; }
    }
}