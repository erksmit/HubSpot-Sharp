namespace HubSpot_Sharp
{
    using System.Runtime.Serialization;

    [DataContract]
    public class Association
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        [DataMember(Name = "type")]
        public string Type { get; set; }
    }
}