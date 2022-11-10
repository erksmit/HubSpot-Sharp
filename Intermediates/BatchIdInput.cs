namespace HubSpot_Sharp.Intermediates
{
    using System.Runtime.Serialization;

    [DataContract]
    public class BatchIdInput
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        public BatchIdInput()
        {
        }

        public BatchIdInput(string id)
        {
            Id = id;
        }
    }
}