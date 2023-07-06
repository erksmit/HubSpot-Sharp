// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyBag.cs" company="">
//   
// </copyright>
// <summary>
//   The property bag.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.Intermediates
{
    /// <summary>
    /// An object containing a HubSpot object and its id
    /// </summary>
    /// <typeparam name="T">
    /// The type of the contained object
    /// </typeparam>
    [DataContract]
    public class PropertyBag<T>
        where T : HubSpotObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyBag{T}"/> class using the provided object.
        /// </summary>
        /// <param name="properties">
        /// The object to put in the bag.
        /// </param>
        /// <param name="id">
        /// The id of the object in the bag.
        /// </param>
        public PropertyBag(T properties, long? id = null)
        {
            Id = id ?? properties.Id;
            Properties = properties;
        }

        /// <summary>
        /// Gets the id of the contained <typeparamref name="T" />.
        /// </summary>
        [DataMember]
        public long? Id { get; }

        /// <summary>
        /// Gets the contained object.
        /// </summary>
        [DataMember]
        public T Properties { get; }

        /// <summary>
        /// Sets the id of the contained <typeparamref name="T" /> and returns it
        /// </summary>
        /// <returns>
        /// The contained <typeparamref name="T" />.
        /// </returns>
        public T GetProperties()
        {
            Properties.Id ??= Id;
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
            return bag.Select(item => item.GetProperties()).ToList();
        }
    }

    public static class PropertyBagEnumerableExtensions
    {
        
        public static IList<T> UnpackMany<T>(this IEnumerable<PropertyBag<T>> bag) where T : HubSpotObject
        {
            return PropertyBag<T>.UnpackMany(bag);
        }
    }
}