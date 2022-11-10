namespace HubSpot_Sharp.Authentication
{
    using System.Runtime.Serialization;

    [DataContract]
    public enum GrantType
    {
        [EnumMember(Value = "authorization_code")]
        AuthorizationCode,

        [EnumMember(Value = "refresh_token")]
        RefreshToken
    }
}