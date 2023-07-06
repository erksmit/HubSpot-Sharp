using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Product
{
    
    [AssociationId("PRODUCT")]
    [ApiPathName("products")]
    [DataContract]
    public class Product : HubSpotObject
    {
        [DataMember]
        public string Description { get; set; }
        
        [DataMember(Name = "hs_cost_of_goods_sold")]
        public double CostOfGoodsSold { get; set; }
        
        [DataMember(Name = "hs_recurring_billing_period")]
        public string RecurringBillingPeriod { get; set; }
        
        [DataMember(Name = "hs_sku")]
        public long Sku { get; set; }
        
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public double Price { get; set; }
    }
}
