namespace HubSpot_Sharp.Serialization
{
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using Newtonsoft.Json.Serialization;

    public class HubSpotSerializer
    {
        private readonly JsonSerializerSettings settings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            Converters = new List<JsonConverter>
               {
                   new StringEnumConverter()
               },
            NullValueHandling = NullValueHandling.Ignore,
            DateFormatString = "yyyy-MM-dd"
        };

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.None, settings);
        }

        public T Deserialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, settings)!;
        }

        public HubSpotSerializer()
        {
        }
    }
}