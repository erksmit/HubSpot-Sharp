// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IdInput.cs" company="">
//   
// </copyright>
// <summary>
//   The id input.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// A string id input for a request
    /// </summary>
    [DataContract]
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
        [DataMember]
        public string Id { get; set; }

        /// <summary>
        /// The from enumerable.
        /// </summary>
        /// <param name="enumerable">
        /// The enumerable.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// </exception>
        public static List<IdInput> FromEnumerable<T>(IEnumerable<T> enumerable)
            where T : HubSpotObject
        {
            return enumerable.Select(
                    o =>
                    {
                        if (o.Id == null)
                        {
                            throw new ArgumentException(
                                "One of more hubspot objects do not have an id defined.",
                                nameof(enumerable));
                        }

                        return new IdInput(o.Id.ToString()!);
                    })
                .ToList();
        }
    }
}