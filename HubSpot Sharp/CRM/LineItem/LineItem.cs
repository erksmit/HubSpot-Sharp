using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.LineItem
{
    
    [AssociationId("LINEITEM")]
    [ApiPathName("line_items")]
    [DataContract]
    public class LineItem : HubSpotObject
    {
        [DataMember(Name = "hs_recurring_billing_period")]
        public string RecurringBillingPeriod { get; set; }

        [DataMember(Name = "hs_product_id")]
        public long ProductId { get; set; }
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public double Price { get; set; }
        
        [DataMember]
        public string RecurringBillingFrequency { get; set; }
        
        [DataMember]
        public int Quantity { get; set; }
    }
}
