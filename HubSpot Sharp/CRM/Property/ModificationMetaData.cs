using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Property
{
    [DataContract]
    public class ModificationMetaData
    {
        public bool ReadOnlyOptions { get; set; }

        public bool ReadOnlyValue { get; set; }

        public bool ReadOnlyDefinition { get; set; }

        public bool Archivable { get; set; }
    }
}
