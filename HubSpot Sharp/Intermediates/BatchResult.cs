namespace HubSpot_Sharp.Intermediates
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class BatchResult<T> where T : new()
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "results")]
        public IList<T> Results { get; set; }
    }
}