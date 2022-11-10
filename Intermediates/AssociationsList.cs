namespace HubSpot_Sharp.Intermediates
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Search;

    [DataContract]
    public class AssociationsList
    {
        [DataMember(Name = "results")]
        public IList<AssociationsListEntry> Results { get; set; }

        [DataMember(Name = "paging")]
        public PagingModel Paging { get; set; }
    }
}