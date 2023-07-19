// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SerializationTests.cs" company="">
//   
// </copyright>
// <summary>
//   The simple properties.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Serialization;

namespace Tests
{
    /// <summary>
    /// The simple properties.
    /// </summary>
    public class SimpleProperties
    {
        /// <summary>
        /// Gets or sets the number prop.
        /// </summary>
        public int NumberProp { get; set; }

        /// <summary>
        /// Gets or sets the string prop.
        /// </summary>
        public string StringProp { get; set; }

        /// <summary>
        /// Gets or sets the date prop.
        /// </summary>
        public DateTime DateProp { get; set; }
    }

    /// <summary>
    /// The reference property.
    /// </summary>
    public class ReferenceProperty
    {
        /// <summary>
        /// Gets or sets the props.
        /// </summary>
        public SimpleProperties Props { get; set; }
    }

    /// <summary>
    /// The deserialize only properties.
    /// </summary>
    public class DeserializeOnlyProperties
    {
        /// <summary>
        /// Gets or sets the prop 1.
        /// </summary>
        public int Prop1 { get; set; }

        /// <summary>
        /// Gets or sets the prop 2.
        /// </summary>
        [DeserializeOnly]
        public int Prop2 { get; set; }
    }

    /// <summary>
    /// The list property.
    /// </summary>
    public class ListProperty
    {
        /// <summary>
        /// Gets or sets the ints.
        /// </summary>
        public IList<int> Ints { get; set; }
    }

    /// <summary>
    /// The enumeration property.
    /// </summary>
    public class EnumerationProperty
    {
        /// <summary>
        /// Gets or sets the enumeration.
        /// </summary>
        [HubSpotEnumeration]
        public IList<string> Enumeration { get; set; }
    }

    /// <summary>
    /// The hub spot object child.
    /// </summary>
    public class HubSpotObjectChild : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// The serialization tests.
    /// </summary>
    [TestClass]
    public class SerializationTests
    {
        /// <summary>
        /// The serializer.
        /// </summary>
        private static readonly HubSpotSerializer serializer = new();

        /// <summary>
        /// The simple serialization.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        [TestMethod]
        public void SimpleSerialization()
        {
            var now = DateTime.Now;
            var simpleObject = new SimpleProperties
            {
                NumberProp = 5,
                StringProp = "woah",
                DateProp = now
            };
            var json = serializer.SerializeJson(simpleObject);
            var parsedObject = serializer.DeserializeJson<SimpleProperties>(json);
            Assert.AreEqual(
                simpleObject.NumberProp,
                parsedObject.NumberProp,
                "Number property does not match parsed object.");
            Assert.AreEqual(
                simpleObject.StringProp,
                parsedObject.StringProp,
                "String property does not match parsed object.");
            Assert.AreEqual(now, parsedObject.DateProp, "Date property does not match parsed object.");
        }

        /// <summary>
        /// The reference serialization.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        [TestMethod]
        public void ReferenceSerialization()
        {
            var referenceObject = new ReferenceProperty
            {
                Props = new SimpleProperties
                {
                    NumberProp = 5
                }
            };
            var json = serializer.SerializeJson(referenceObject);
            var parsedObject = serializer.DeserializeJson<ReferenceProperty>(json);
            Assert.AreEqual(
                referenceObject.Props.NumberProp,
                parsedObject.Props.NumberProp,
                "Number property does not match parsed object.");
        }

        /// <summary>
        /// The list serialization.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        [TestMethod]
        public void ListSerialization()
        {
            var ints = new List<int>
            {
                1,
                3,
                5
            };
            var listObject = new ListProperty
            {
                Ints = ints
            };
            var json = serializer.SerializeJson(listObject);
            var parsedObject = serializer.DeserializeJson<ListProperty>(json);

            // this check is flawed
            Assert.IsTrue(
                parsedObject.Ints.All(ints.Contains),
                "Parsed object did not contain a number it was supposed to.");
        }

        /// <summary>
        /// The property bag serialization.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        [TestMethod]
        public void PropertyBagSerialization()
        {
            var bag = new PropertyBag<HubSpotObjectChild>(
                new HubSpotObjectChild
                {
                    Id = 1,
                    Name = "foo",
                    Value = "bar"
                });
            var json = serializer.SerializeJson(bag);
            var parsedObject = serializer.DeserializeJson<PropertyBag<HubSpotObjectChild>>(json);
        }
    }
}