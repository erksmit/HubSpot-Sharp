using System.Runtime.Serialization;

namespace HubSpot_Sharp
{
    [DataContract]
    public class HubSpotExceptionBody
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "message")]
        public string Message { get; set; }

        [DataMember(Name = "category")]
        public string Category { get; set; }

        [DataMember(Name = "subCategory")]
        public string SubCategory { get; set; }
    }
}
