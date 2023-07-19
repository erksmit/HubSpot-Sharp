// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Product.cs" company="">
//   
// </copyright>
// <summary>
//   The product.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Product
{
    /// <summary>
    /// The product.
    /// </summary>
    [AssociationId("PRODUCT")]
    [ApiPathName("products")]
    [DataContract]
    public class Product : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        [DataMember]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the cost of goods sold.
        /// </summary>
        [DataMember(Name = "hs_cost_of_goods_sold")]
        public double CostOfGoodsSold { get; set; }

        /// <summary>
        /// Gets or sets the recurring billing period.
        /// </summary>
        [DataMember(Name = "hs_recurring_billing_period")]
        public string RecurringBillingPeriod { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        [DataMember(Name = "hs_sku")]
        public long Sku { get; set; }

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
    }
}