// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NameInput.cs" company="">
//   
// </copyright>
// <summary>
//   The name input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// A string name input for certain requests
    /// </summary>
    [DataContract]
    public class NameInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NameInput" /> class.
        /// </summary>
        public NameInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NameInput"/> class using the provided name.
        /// </summary>
        /// <param name="name">
        /// The name to use.
        /// </param>
        public NameInput(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}