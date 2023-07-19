using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{

    [DataContract]
    public class LoginActivity
    {
        [JsonConstructor]
        internal LoginActivity(string id, DateTime loginAt, long userId, string email, string countryCode, string regionCode, string ipAddress, string userAgent, bool loginSucceeded)
        {
            Id = id;
            LoginAt = loginAt;
            UserId = userId;
            Email = email;
            CountryCode = countryCode;
            RegionCode = regionCode;
            IpAddress = ipAddress;
            UserAgent = userAgent;
            LoginSucceeded = loginSucceeded;
        }

        [DataMember]
        public string Id { get; }

        [DataMember]
        public DateTime LoginAt { get; }

        [DataMember]
        public long UserId { get; }

        [DataMember]
        public string Email { get; }

        [DataMember]
        public string CountryCode { get; }

        [DataMember]
        public string RegionCode { get; }

        [DataMember]
        public string IpAddress { get; }

        [DataMember]
        public string UserAgent { get; }

        [DataMember]
        public bool LoginSucceeded { get; }
    }
}
