namespace HubSpot_Sharp.Intermediates
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using HubSpot_Sharp;

    [DataContract]
    public class BatchInputs<T>
        where T : HubSpotBaseModel, new()
    {
        /// <summary>
        /// The companies to be updated.
        /// </summary>
        [DataMember(Name = "inputs")]
        public IList<PropertyBag<T>> Inputs { get; set; }

        public BatchInputs()
        {
            Inputs = new List<PropertyBag<T>>();
        }

        public BatchInputs(IList<T> inputs)
        {
            Inputs = inputs.Select(PropertyBag<T>.Pack).ToList();
        }
    }
}