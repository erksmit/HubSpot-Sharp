using System.Runtime.Serialization;

namespace HubSpot_Sharp.AccountActivity
{
    [DataContract]
    public class LoginActivity
    {
        public string Id { get; set; }

        public DateTime LoginAt { get; set; }

        public long UserId { get; set; }

        public string Email { get; set; }

        public string CountryCode { get; set; }

        public string RegionCode { get; set; }

        public string IpAddress { get; set; }

        public string UserAgent { get; set; }
  
        public bool LoginSucceeded { get; set; }
    }
}
