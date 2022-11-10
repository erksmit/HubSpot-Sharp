namespace HubSpot_Sharp
{
    using System.Runtime.Serialization;

    [DataContract]
    public class HubSpotBaseModel
    {
        [DataMember(Name = "id")]
        public long? Id { get; set; }
    }
}