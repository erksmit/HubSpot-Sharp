using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.Associations
{
    [DataContract]
    public class AssociationIdInput
    {
        [DataMember]
        public IdObject From { get; set; }
        
        [DataMember]
        public IdObject To { get; set; }
    }
}
