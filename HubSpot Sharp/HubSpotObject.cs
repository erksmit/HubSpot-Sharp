namespace HubSpot_Sharp
{
    using System.Runtime.Serialization;

    using HubSpot_Sharp.Serialization;

    using Newtonsoft.Json;

    [DataContract]
    public class HubSpotObject
    {
        [DataMember(Name = "id")]
        public long? Id { get; set; }
        
        [DataMember(Name = "createdate")]
        [JsonConverter(typeof(ReadOnlyDateConverter))]
        public DateTime Created { get; set; }

        [DataMember(Name = "hs_lastmodifieddate")]
        [JsonConverter(typeof(ReadOnlyDateConverter))]
        public DateTime LastModified { get; set; }
    }
}