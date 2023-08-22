using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Associations.Schema
{
    [DataContract]
    public class AssociationType
    {
        /// <summary>
        /// Gets or sets whether the association type was created by HubSpot (HUBSPOT_DEFINED) or by a user (USER_DEFINED).
        /// </summary>
        [DataMember]
        public AssociationCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the numeric ID for that association type. If the label is hubspot defined it can be found in the AssociationType enum classes.
        /// </summary>
        [DataMember]
        public int TypeId { get; set; }

        /// <summary>
        /// Gets or sets the alphanumeric label. This will be null for the unlabeled association type.
        /// </summary>
        [DataMember]
        public string? Label { get; set; }
    }
}
