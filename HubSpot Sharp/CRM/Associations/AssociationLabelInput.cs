using System.Runtime.Serialization;

using HubSpot_Sharp.CRM.Associations.Schema;
using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.Associations
{
    [DataContract]
    public class AssociationLabelInput
    {
        [DataMember]
        public IdObject From { get; set; }
        
        [DataMember]
        public IdObject To { get; set; }

        [DataMember]
        public IList<AssociationType> Types { get; set; }
    }
}
