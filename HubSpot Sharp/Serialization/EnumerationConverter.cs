// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumerationConverter.cs" company="">
//   
// </copyright>
// <summary>
//   Used to serialize/deserialize HubSpot's semicolon delimited lists of strings
// </summary>
// --------------------------------------------------------------------------------------------------------------------


using Newtonsoft.Json;

namespace HubSpot_Sharp.Serialization
{
    /// <summary>
    /// Used to serialize/deserialize HubSpot's semicolon delimited lists of strings
    /// </summary>
    public class EnumerationConverter : JsonConverter<IList<string>>
    {

        public override IList<string>? ReadJson(JsonReader reader, Type objectType, IList<string>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            
            string? json = (string?)reader.Value;
            if (string.IsNullOrEmpty(json))
            {
                return new List<string>();
            }

            List<string> elements = json.Split(';').ToList();
            return elements;
        }

        public override void WriteJson(JsonWriter writer, IList<string>? value, JsonSerializer serializer)
        {
            if (value == null)
            {
                return;
            }

            var result = string.Join(";", value);
            writer.WriteValue(result);
        }
    }
}