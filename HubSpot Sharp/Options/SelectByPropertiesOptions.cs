using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.Options
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [DataContract]
    public class SelectByPropertiesOptions
    {
        [DataMember(Name = "properties")]
        public IList<string> PropertiesToRead { get; set; }

        [DataMember(Name = "idProperty")]
        public string IdProperty { get; set; }

        [DataMember(Name = "inputs")]
        public IList<IdInput> Inputs { get; set; }

        public SelectByPropertiesOptions()
        {
        }

        public SelectByPropertiesOptions(IEnumerable<string> inputs)
        {
            Inputs = inputs.Select(i => new IdInput(i)).ToList();
        }

        public SelectByPropertiesOptions(string id, IEnumerable<string> inputs, IList<string> propertiesToRead)
        {
            IdProperty = id;
            Inputs = inputs.Select(i => new IdInput(i)).ToList();
            PropertiesToRead = propertiesToRead;
        }
    }
}