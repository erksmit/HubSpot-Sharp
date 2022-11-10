namespace HubSpot_Sharp.Company
{
    using System.Runtime.Serialization;

    using HubSpot_Sharp;

    [DataContract]
    public class BaseCompany : HubSpotBaseModel
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "domain")]
        public string Domain { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }
    }
}