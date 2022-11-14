namespace HubSpot_Sharp.Serialization
{
    using Newtonsoft.Json;

    internal class ReadOnlyDateConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteRawValue("null");
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
           return (DateTime)reader.Value!;
        }
    }
}
