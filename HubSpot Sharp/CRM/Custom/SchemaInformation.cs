namespace HubSpot_Sharp.CRM.Custom
{
    using System.Runtime.Serialization;

    using HubSpot_Sharp;

    [DataContract]
    public class SchemaInformation : HubSpotObject
    {
        /// <summary>
        /// A unique name for the schema's object type.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// An assigned unique ID for the object, including portal ID and object name.
        /// </summary>
        [DataMember(Name = "fullyQualifiedName")]
        public string FullyQualifiedName { get; set; }

        /// <summary>
        /// The id used to identify the schema in future requests
        /// </summary>
        [DataMember(Name = "objectTypeId")]
        public string ObjectTypeId { get; set; }
    }
}