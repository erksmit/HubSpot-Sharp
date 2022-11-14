namespace HubSpot_Sharp.CRM.Property
{
    using System.Runtime.Serialization;

    [DataContract]
    public class ModificationMetaData
    {
        [DataMember(Name = "readOnlyOptions")]
        public bool ReadOnlyOptions { get; set; }

        [DataMember(Name = "readOnlyValue")]
        public bool ReadOnlyValue { get; set; }

        [DataMember(Name = "readOnlyDefinition")]
        public bool ReadOnlyDefinition { get; set; }

        [DataMember(Name = "archivable")]
        public bool Archivable { get; set; }
    }
}
