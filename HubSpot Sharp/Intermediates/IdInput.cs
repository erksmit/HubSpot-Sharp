// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdInput.cs" company="">
//   
// </copyright>
// <summary>
//   The id input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// A string id input for a request
    /// </summary>
    public class IdInput
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IdInput" /> class.
        /// </summary>
        public IdInput()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IdInput"/> class with the provided id.
        /// </summary>
        /// <param name="id">
        /// The id to use.
        /// </param>
        public IdInput(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        public string Id { get; set; }
    }
}