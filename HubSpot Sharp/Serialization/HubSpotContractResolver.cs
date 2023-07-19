// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotContractResolver.cs" company="">
//   
// </copyright>
// <summary>
//   The hub spot contract resolver.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HubSpot_Sharp.Serialization
{
    /// <summary>
    /// A custom contract resolver with additional attributes relevant to HubSpot's api.
    /// </summary>
    public class HubSpotContractResolver : DefaultContractResolver
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HubSpotContractResolver" /> class.
        /// </summary>
        public HubSpotContractResolver()
        {
            NamingStrategy = new CamelCaseNamingStrategy();
        }

        /// <inheritdoc />
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            if (member.GetCustomAttribute<DeserializeOnlyAttribute>() != null)
            {
                property.ShouldSerialize = _ => false;
            }

            if (member.GetCustomAttribute<HubSpotEnumerationAttribute>() != null)
            {
                property.Converter = new EnumerationConverter();
            }

            return property;
        }
    }
}