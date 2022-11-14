namespace HubSpot_Sharp.Intermediates
{
    using System.Runtime.Serialization;

    [DataContract]
    public class IdInput
    {
        [DataMember(Name = "id")]
        public string Id { get; set; }

        public IdInput()
        {
        }

        public IdInput(string id)
        {
            Id = id;
        }
    }
}