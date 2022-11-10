namespace HubSpot_Sharp.Intermediates
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class BatchIdInputs
    {
        [DataMember(Name = "properties")]
        public IList<string> PropertiesToRead { get; set; }

        [DataMember(Name = "idProperty")]
        public string IdProperty { get; set; }

        [DataMember(Name = "inputs")]
        public IList<BatchIdInput> Inputs { get; set; }

        public BatchIdInputs()
        {
        }

        public BatchIdInputs(IEnumerable<string> inputs)
        {
            Inputs = inputs.Select(i => new BatchIdInput(i)).ToList();
        }

        public BatchIdInputs(string id, IEnumerable<string> inputs, IList<string> propertiesToRead)
        {
            IdProperty = id;
            Inputs = inputs.Select(i => new BatchIdInput(i)).ToList();
            PropertiesToRead = propertiesToRead;
        }
    }
}