using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.LineItem
{
    public class LineItem : HubSpotObject
    {
        [DataMember(Name = "hs_recurring_billing_period")]
        public string RecurringBillingPeriod { get; set; }

        [DataMember(Name = "hs_product_id")]
        public long ProductId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "price")]
        public double Price { get; set; }

        [DataMember(Name = "recurringbillingfrequency")]
        public string RecurringBillingFrequency { get; set; }

        [DataMember(Name = "quantity")]
        public int Quantity { get; set; }
    }
}
