// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyBag.cs" company="">
//   
// </copyright>
// <summary>
//   The property bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// An object containing a HubSpot object and its id
    /// </summary>
    /// <typeparam name="T">
    /// The type of the contained object
    /// </typeparam>
    public class PropertyBag<T>
        where T : HubSpotObject, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBag{T}" /> class.
        /// </summary>
        public PropertyBag()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBag{T}"/> class using the provided object.
        /// </summary>
        /// <param name="obj">
        /// The object to put in the bag.
        /// </param>
        public PropertyBag(T obj)
        {
            Id = obj.Id;
            Properties = obj;
        }

        /// <summary>
        /// Gets or sets the id of the contained <typeparamref name="T" />.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets the contained object.
        /// </summary>
        public T Properties { get; set; }

        /// <summary>
        /// Sets the id of the contained <typeparamref name="T" /> and returns it
        /// </summary>
        /// <returns>
        /// The contained <typeparamref name="T" />.
        /// </returns>
        public T Unpack()
        {
            Properties.Id = (long)Id;
            return Properties;
        }

        /// <summary>
        /// Transforms a <see cref="IEnumerable{T}"/> into a list of propertyBags
        /// </summary>
        /// <param name="inputs">
        /// The objects to pack.
        /// </param>
        /// <returns>
        /// The packed objects.
        /// </returns>
        public static IList<PropertyBag<T>> PackMany(IEnumerable<T> inputs)
        {
            return inputs.Select(i => new PropertyBag<T>(i)).ToList();
        }

        /// <summary>
        /// Gets a list of objects from a set of propertyBags
        /// </summary>
        /// <param name="bag">
        /// The set of bags to unpack.
        /// </param>
        /// <returns>
        /// A list of the unpacked objects.
        /// </returns>
        public static IList<T> UnpackMany(IEnumerable<PropertyBag<T>> bag)
        {
            return bag.Select(item => item.Unpack()).ToList();
        }
    }
}