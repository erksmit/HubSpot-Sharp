namespace HubSpot_Sharp.Search
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class SearchOptions
    {
        [DataMember(Name = "filterGroups")]
        public IList<FilterGroup> FilterGroups { get; set; }

        [DataMember(Name = "query")]
        public string Query { get; set; }

        [DataMember(Name = "properties")]
        public IList<string> PropertiesToInclude { get; set; }

        [DataMember(Name = "sorts")]
        public IList<string> Sorts { get; set; }

        [DataMember(Name = "limit")]
        public int Limit { get; set; }

        [DataMember(Name = "after")]
        public string After { get; set; }
    }
}