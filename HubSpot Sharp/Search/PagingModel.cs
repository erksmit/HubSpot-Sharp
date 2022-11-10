namespace HubSpot_Sharp.Search
{
    using System.Runtime.Serialization;

    [DataContract]
    public class PagingModel
    {
        [DataMember(Name = "next")]
        public NextModel Next { get; set; }
    }
}