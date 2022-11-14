namespace HubSpot_Sharp.Intermediates
{
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract]
    public class ListInputs<T>
    {
        /// <summary>
        /// The companies to be updated.
        /// </summary>
        [DataMember(Name = "inputs")]
        public IList<T> Inputs { get; set; }

        public ListInputs()
        {
            Inputs = new List<T>(); }

        public ListInputs(IList<T> inputs)
        {
            Inputs = inputs;
        }
    }
}