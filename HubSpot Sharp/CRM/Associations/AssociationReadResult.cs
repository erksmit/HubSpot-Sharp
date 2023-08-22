using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Search;

namespace HubSpot_Sharp.CRM.Associations
{
    [DataContract]
    public class AssociationReadResult
    {
        [DataMember]
        public IdObject From { get; set; }
        
        [DataMember]
        public PagingModel Paging { get; set; }
        
        [DataMember]
        public IList<AssociationsListEntry> To { get; set; }
    }
}
