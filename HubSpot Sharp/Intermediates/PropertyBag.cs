namespace HubSpot_Sharp.Intermediates
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    using HubSpot_Sharp;

    [DataContract]
    public class PropertyBag<T> : HubSpotObject, IDisposable
        where T : HubSpotObject, new()
    {
        [DataMember(Name = "properties")]
        public T Properties { get; set; }

        public static PropertyBag<T> Pack(T obj)
        {
            var bag = new PropertyBag<T>
            {
                Id = obj.Id,
                Properties = obj
            };
            obj.Id = null;
            return bag;
        }

        public T Unpack()
        {
            Properties.Id = Id;
            return Properties;
        }

        public static IList<PropertyBag<T>> PackMany(IEnumerable<T> inputs)
        {
            return inputs.Select(Pack).ToList();
        }

        public static IList<T> UnpackMany(IList<PropertyBag<T>> bag)
        {
            return bag.Select(item => item.Unpack()).ToList();
        }

        public void Dispose()
        {
            Unpack();
        }
    }
}