using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{
    [DataContract]
    public class SecurityActivity
    {
        [JsonConstructor]
        internal SecurityActivity(string id, DateTime createdAt, long userId, string type, string actingUser, string objectId, string infoUrl, string ipAddress, string countryCode, string regionCode)
        {
            Id = id;
            CreatedAt = createdAt;
            UserId = userId;
            Type = type;
            ActingUser = actingUser;
            ObjectId = objectId;
            InfoUrl = infoUrl;
            IpAddress = ipAddress;
            CountryCode = countryCode;
            RegionCode = regionCode;
        }

        [DataMember]
        public string Id { get; }

        [DataMember]
        public DateTime CreatedAt { get; }

        [DataMember]
        public long UserId { get; }

        [DataMember]
        public string Type { get; }

        [DataMember]
        public string ActingUser { get; }

        [DataMember]
        public string ObjectId { get; }

        [DataMember]
        public string InfoUrl { get; }

        [DataMember]
        public string IpAddress { get; }

        [DataMember]
        public string CountryCode { get; }

        [DataMember]
        public string RegionCode { get; }
    }
}
