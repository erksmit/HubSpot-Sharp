namespace HubSpot_Sharp.CRM.Property
{
    using System.Runtime.Serialization;

    using HubSpot_Sharp.CRM.Custom;
    
    [DataContract]
    public class PropertyInformation : ObjectProperty
    {
        public string GroupName { get; set; }

        public bool Hidden { get; set; }

        public ModificationMetaData ModificationMetaData { get; set; }

        public int DisplayOrder { get; set; }

        public bool FormField { get; set; }

        public bool Calculated { get; set; }

        public bool Archived { get; set; }

        public bool ExternalOptions { get; set; }
    }
}
