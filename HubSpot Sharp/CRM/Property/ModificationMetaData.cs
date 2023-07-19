using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    [DataContract]
    public class ModificationMetaData
    {
        [DataMember]
        public bool ReadOnlyOptions { get; set; }

        [DataMember]
        public bool ReadOnlyValue { get; set; }

        [DataMember]
        public bool ReadOnlyDefinition { get; set; }

        [DataMember]
        public bool Archivable { get; set; }
    }
}
