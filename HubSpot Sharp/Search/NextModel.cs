namespace HubSpot_Sharp.Search
{
    using System.Runtime.Serialization;

    [DataContract]
    public class NextModel
    {
        [DataMember(Name = "after")]
        public string After { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }
    }
}