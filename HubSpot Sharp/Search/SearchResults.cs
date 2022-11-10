namespace HubSpot_Sharp.Search
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;

    [DataContract]
    public class SearchResults<T>
        where T : HubSpotBaseModel, new()
    {
        [DataMember(Name = "total")]
        public int Total { get; set; }

        [DataMember(Name = "paging")]
        public PagingModel Paging { get; set; }

        [DataMember(Name = "results")]
        public IList<PropertyBag<T>> Results { get; set; }

        public IList<T> UnpackResults() => PropertyBag<T>.UnpackBags(Results);
    }
}