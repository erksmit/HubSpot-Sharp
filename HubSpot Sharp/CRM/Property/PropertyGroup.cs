using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    [DataContract]
    public class PropertyGroup
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int DisplayOrder { get; set; }

        [DataMember]
        public string Label { get; set; }
    }
}
