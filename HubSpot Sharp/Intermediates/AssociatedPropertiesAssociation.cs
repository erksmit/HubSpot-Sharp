using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using HubSpot_Sharp.CRM.Associations.Schema;

namespace HubSpot_Sharp.Intermediates
{
    [DataContract]
    public class AssociatedPropertiesAssociation
    {
        [DataMember]
        public IdInput To { get; set; }
        
        [DataMember]
        public IList<AssociationSchema> types { get; set; }
    }
}
