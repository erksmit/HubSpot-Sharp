namespace HubSpot_Sharp.Intermediates
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    using HubSpot_Sharp;

    [DataContract]
    public class BatchResult<T>
        where T : HubSpotBaseModel, new()
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "results")]
        public IList<PropertyBag<T>> Results { get; set; } = new List<PropertyBag<T>>();
    }
}