using System.Runtime.Serialization;

namespace HubSpot_Sharp.AccountActivity
{
    [DataContract]
    public class SecurityActivity
    {
        public string Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public long UserId { get; set; }

        public string Type { get; set; }

        public string ActingUser { get; set; }

        public string ObjectId { get; set; }

        public string InfoUrl { get; set; }

        public string IpAddress { get; set; }

        public string CountryCode { get; set; }

        public string RegionCode { get; set; }
    }
}
