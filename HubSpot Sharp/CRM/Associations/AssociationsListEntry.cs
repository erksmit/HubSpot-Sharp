using System.Runtime.Serialization;

using HubSpot_Sharp.CRM.Associations.Schema;

namespace HubSpot_Sharp.CRM.Associations
{
    [DataContract]
    public class AssociationsListEntry
    {
        [DataMember]
        public IList<AssociationType> AssociationTypes { get; set; }

        [DataMember]
        public int ToObjectId { get; set; }
    }
}
