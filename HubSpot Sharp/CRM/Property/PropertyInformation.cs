namespace HubSpot_Sharp.CRM.Property
{
    using System.Runtime.Serialization;

    using HubSpot_Sharp.CRM.Custom;
    
    [DataContract]
    public class PropertyInformation : ObjectProperty
    {
        [DataMember]
        public string GroupName { get; set; }
        
        [DataMember]
        public bool Hidden { get; set; }
        
        [DataMember]
        public ModificationMetaData ModificationMetaData { get; set; }
        
        [DataMember]
        public int DisplayOrder { get; set; }
        
        [DataMember]
        public bool FormField { get; set; }
        
        [DataMember]
        public bool Calculated { get; set; }
        
        [DataMember]
        public bool Archived { get; set; }
        
        [DataMember]
        public bool ExternalOptions { get; set; }
    }
}
