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
        /// <summary>
        /// The read json.
        /// </summary>
        /// <param name="reader">
        /// The reader.
        /// </param>
        /// <param name="objectType">
        /// The object type.
        /// </param>
        /// <param name="existingValue">
        /// The existing value.
        /// </param>
        /// <param name="hasExistingValue">
        /// The has existing value.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public override IList<string>? ReadJson(
            JsonReader reader,
            Type objectType,
            IList<string>? existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            string? json = (string?)reader.Value;
            if (string.IsNullOrEmpty(json))
            {
                return new List<string>();
            }

            List<string> elements = json.Split(';').ToList();
            return elements;
        }

        /// <summary>
        /// The write json.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <param name="serializer">
        /// The serializer.
        /// </param>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
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