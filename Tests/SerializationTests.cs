using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using HubSpot_Sharp.Serialization;

namespace Tests
{
    [DataContract]
    public class SimpleProperties
    {
        public int NumberProp { get; set; }

        public string StringProp { get; set; }

        public DateTime DateProp { get; set; }
    }
    
    [DataContract]
    public class ReferenceProperty
    {
        public SimpleProperties Props { get; set; }
    }

    [DataContract]
    public class DeserializeOnlyProperties
    {
        public int Prop1 { get; set; }

        [DeserializeOnly]
        public int Prop2 { get; set;}
    }

    [DataContract]
    public class ListProperty
    {
        public IList<int> Ints { get; set; }
    }

    [DataContract]
    public class EnumerationProperty
    {
        [HubSpotEnumeration]
        public IList<string> Enumeration { get; set; }
    }

    [TestClass]
    public class SerializationTests
    {
        private static HubSpotSerializer serializer = new ();

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
            Assert.AreEqual(simpleObject.NumberProp, parsedObject.NumberProp, "Number property does not match parsed object.");
            Assert.AreEqual(simpleObject.StringProp, parsedObject.StringProp, "String property does not match parsed object.");
            Assert.AreEqual(now, parsedObject.DateProp, "Date property does not match parsed object.");
        }

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
            Assert.IsTrue(parsedObject.Ints.All(ints.Contains), "Parsed object did not contain a number it was supposed to.");
        }
    }
}
