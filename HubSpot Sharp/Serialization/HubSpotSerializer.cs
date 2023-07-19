// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotSerializer.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot serializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Net;
using System.Reflection;
using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace HubSpot_Sharp.Serialization
{
    /// <summary>
    /// The HubSpot json serializer.
    /// </summary>
    public class HubSpotSerializer
    {
        /// <summary>
        /// The settings for the serializer.
        /// </summary>
        private readonly JsonSerializerSettings settings = new()
        {
            ContractResolver = new HubSpotContractResolver(),
            Converters = new List<JsonConverter>
            {
                new StringEnumConverter(new CamelCaseNamingStrategy())
            },
            NullValueHandling = NullValueHandling.Ignore,
        };

        /// <summary>
        /// Serializes an object into its json representation.
        /// </summary>
        /// <param name="obj">
        /// The object to serialize.
        /// </param>
        /// <returns>
        /// A json string of the serialized object.
        /// </returns>
        public string SerializeJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        /// <summary>
        /// Serializes an object into a url encoded set of key value pairs. Handles object references with ToString.
        /// </summary>
        /// <param name="obj">
        /// The object to convert.
        /// </param>
        /// <returns>
        /// The serialized string.
        /// </returns>
        public string SerializeUrlEncoded(object obj)
        {
            var camelCaseNaming = new CamelCaseNamingStrategy();
            List<(string name, string value)> formMembers = new List<(string name, string value)>();

            var type = obj.GetType();
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                var propertyType = property.PropertyType;
                var propertyValue = property.GetValue(obj);
                if (propertyValue == null)
                {
                    continue;
                }

                var dataAttr = property.GetCustomAttribute<DataMemberAttribute>();

                string propertyName;
                string finalValue;
                if (dataAttr != null && string.IsNullOrEmpty(dataAttr.Name) == false)
                {
                    propertyName = dataAttr.Name;
                }
                else
                {
                    // use camelcase naming strategy if there is no custom name defined
                    propertyName = camelCaseNaming.GetPropertyName(property.Name, false);
                }

                if (propertyType.IsEnum)
                {
                    // get the name of the enum field
                    var enumValueName = Enum.GetName(propertyType, propertyValue)!;
                    var enumField = propertyType.GetField(enumValueName)!;
                    var enumMemberAttribute = enumField.GetCustomAttribute<EnumMemberAttribute>();

                    // use the enum member attribute's value if it is defined
                    if (enumMemberAttribute != null && string.IsNullOrEmpty(enumMemberAttribute.Value) == false)
                    {
                        finalValue = enumMemberAttribute.Value;
                    }
                    else
                    {
                        finalValue = enumValueName;
                    }
                }
                else if (propertyType == typeof(DateTime))
                {
                    var date = (DateTime)propertyValue;
                    finalValue = date.ToString("yyyy-MM-dd");
                }
                else
                {
                    finalValue = propertyValue.ToString()!;
                }

                formMembers.Add((name: propertyName, value: finalValue));
            }

            // format the members and escape the values
            return string.Join(
                "&",
                formMembers.Select(
                    m =>
                    {
                        var name = WebUtility.UrlEncode(m.name);
                        var value = WebUtility.UrlEncode(m.value);
                        return $"{name}={value}";
                    }));
        }

        /// <summary>
        /// Deserializes a json into an object.
        /// </summary>
        /// <param name="json">
        /// The json to Deserialize.
        /// </param>
        /// <typeparam name="T">
        /// The object type to Deserialize into.
        /// </typeparam>
        /// <returns>
        /// The Deserialized object
        /// </returns>
        public T DeserializeJson<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings)!;
        }
    }
}