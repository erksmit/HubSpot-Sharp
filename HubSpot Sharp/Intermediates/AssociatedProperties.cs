using System.Runtime.Serialization;

namespace HubSpot_Sharp.Intermediates
{
    [DataContract]
    public class AssociatedProperties<T>
    {
        public AssociatedProperties() { }

        public AssociatedProperties(T value, IList<AssociatedPropertiesAssociation>? associations = null)
        {
            Properties = value;
            Associations = associations;
        }

        [DataMember]
        public T Properties { get; set; }
        
        [DataMember]
        public IList<AssociatedPropertiesAssociation>? Associations { get; set; }

    }
}
