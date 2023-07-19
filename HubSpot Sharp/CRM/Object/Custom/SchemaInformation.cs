// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SchemaInformation.cs" company="">
//   
// </copyright>
// <summary>
//   The schema information.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.Custom
{
    /// <summary>
    /// Additional information about an objectSchema obtainable after creation.
    /// </summary>
    [DataContract]
    public class SchemaInformation : ObjectSchema
    {
        /// <summary>
        /// Gets or sets An assigned unique ID for the object, including portal ID and object name.
        /// </summary>
        [DataMember]
        public string FullyQualifiedName { get; set; }

        /// <summary>
        /// Gets or sets The id used to identify the schema in future requests
        /// </summary>
        [DataMember]
        public string ObjectTypeId { get; set; }
    }
}