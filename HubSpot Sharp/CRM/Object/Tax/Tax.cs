using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Tax
{
    [DataContract]
    [AssociationId("TAX")]
    [ApiPathName("taxes")]
    public class Tax : HubSpotObject
    {
        [DataMember(Name = "hs_label")]
        public string Label { get; set; }

        [DataMember(Name = "hs_type")]
        public TaxType Type { get; set; }

        [DataMember(Name = "hs_value")]
        public string Value { get; set; }
    }
}
