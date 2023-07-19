// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LineItem.cs" company="">
//   
// </copyright>
// <summary>
//   The line item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.LineItem
{
    /// <summary>
    /// The line item.
    /// </summary>
    [AssociationId("LINEITEM")]
    [ApiPathName("line_items")]
    [DataContract]
    public class LineItem : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the recurring billing period.
        /// </summary>
        [DataMember(Name = "hs_recurring_billing_period")]
        public string RecurringBillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        [DataMember(Name = "hs_product_id")]
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        [DataMember]
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the recurring billing frequency.
        /// </summary>
        [DataMember]
        public string RecurringBillingFrequency { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        [DataMember]
        public int Quantity { get; set; }
    }
}