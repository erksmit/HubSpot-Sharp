using System.Runtime.Serialization;
using HubSpot_Sharp.CRM.Associations.Schema;
using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.Associations
{
    [DataContract]
    public class CreatedDefaultAssociation
    {
        [DataMember]
        public AssociationType AssociationSpec { get; set; }

        [DataMember]
        public IdObject From { get; set; }

        [DataMember]
        public IdObject? to { get; set; }
    }
}
