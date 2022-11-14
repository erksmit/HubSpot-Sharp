namespace HubSpot_Sharp.CRM.Property
{
    using System.Runtime.Serialization;

    using HubSpot_Sharp.CRM.Custom;

    [DataContract]
    public class PropertyInformation : ObjectProperty
    {
        [DataMember(Name = "groupName")]
        public string GroupName { get; set; }

        [DataMember(Name = "hidden")]
        public bool Hidden { get; set; }

        [DataMember(Name = "modificationMetaData")]
        public ModificationMetaData ModificationMetaData { get; set; }

        [DataMember(Name = "displayOrder")]
        public int DisplayOrder { get; set; }

        [DataMember(Name = "formField")]
        public bool FormField { get; set; }
    }
}
