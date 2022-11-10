namespace HubSpot_Sharp.Search
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class Filter
    {
        [DataMember(Name = "value")]
        public string Value { get; set; }

        [DataMember(Name = "values")]
        public IList<string> Values { get; set; }

        [DataMember(Name = "propertyName")]
        public string PropertyName { get; set; }

        [DataMember(Name = "operator")]
        public SearchOperator Operator { get; set; }
    }
}