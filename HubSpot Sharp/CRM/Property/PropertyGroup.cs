namespace HubSpot_Sharp.CRM.Property
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PropertyGroup
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        
        [DataMember(Name = "displayOrder")]
        public int DisplayOrder { get; set; }
        
        [DataMember(Name = "label")]
        public string Label { get; set; }
    }
}
