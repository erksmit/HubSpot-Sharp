using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.LineItem
{
    [DataContract]
    [AssociationId("LINEITEM")]
    [ApiPathName("line_items")]
    public class LineItem : HubSpotObject
    {
        [DataMember(Name = "hs_recurring_billing_period")]
        public string RecurringBillingPeriod { get; set; }

        [DataMember(Name = "hs_product_id")]
        public long ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string RecurringBillingFrequency { get; set; }

        public int Quantity { get; set; }
    }
}
