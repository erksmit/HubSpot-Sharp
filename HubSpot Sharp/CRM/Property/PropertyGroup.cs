using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    [DataContract]
    public class PropertyGroup
    {
        public string Name { get; set; }
        
        public int DisplayOrder { get; set; }
        
        public string Label { get; set; }
    }
}
