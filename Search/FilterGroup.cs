namespace HubSpot_Sharp.Search
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class FilterGroup
    {
        [DataMember(Name = "filters")]
        public IList<Filter> Filters { get; set; }
    }
}