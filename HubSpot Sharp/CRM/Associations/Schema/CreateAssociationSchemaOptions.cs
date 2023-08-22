// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateAssociationSchemaOptions.cs" company="">
//   
// </copyright>
// <summary>
//   The create association schema options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Associations.Schema
{
    /// <summary>
    /// The body for creating a new association type.
    /// </summary>
    [DataContract]
    public class CreateAssociationSchemaOptions
    {
        /// <summary>
        /// Gets or sets the label of the association.
        /// </summary>
        [DataMember]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the display name for the association, this cannot be edited later.
        /// </summary>
        [DataMember]
        public string Name { get; set; }
    }
}