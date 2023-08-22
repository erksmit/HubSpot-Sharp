namespace HubSpot_Sharp.CRM.Associations.Schema
{
    public class AssociationSchema
    {
        /// <summary>
        /// Gets or sets whether the association type was created by HubSpot (HUBSPOT_DEFINED) or by a user (USER_DEFINED).
        /// </summary>
        public AssociationCategory Category { get; set; }

        /// <summary>
        /// Gets or sets the numeric ID for that association type. If the label is hubspot defined it can be found in the AssociationType enum classes.
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// Gets or sets the alphanumeric label. This will be null for the unlabeled association type.
        /// </summary>
        public string? Label { get; set; }
    }
}
