namespace HubSpot_Sharp.Custom
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class SchemaListResult
    {
        [DataMember(Name = "results")]
        public IList<CustomSchemaResponse> Schemas { get; set; }
    }
}