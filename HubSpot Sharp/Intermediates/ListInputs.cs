// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ListInputs.cs" company="">
//   
// </copyright>
// <summary>
//   The list inputs.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// A list of inputs used for some requests.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the inputs
    /// </typeparam>
    [DataContract]
    public class ListInputs<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ListInputs{T}" /> class.
        /// </summary>
        public ListInputs()
        {
            Inputs = new List<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ListInputs{T}"/> class using the provided list.
        /// </summary>
        /// <param name="inputs">
        /// The inputs to use.
        /// </param>
        public ListInputs(IList<T> inputs)
        {
            Inputs = inputs;
        }

        /// <summary>
        /// Gets or sets the list of input objects.
        /// </summary>
        [DataMember]
        public IList<T> Inputs { get; set; }
    }
}