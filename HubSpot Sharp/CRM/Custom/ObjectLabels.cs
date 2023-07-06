// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectLabels.cs" company="">
//   
// </copyright>
// <summary>
//   Display names of an object schema.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Custom
{
    /// <summary>
    /// Display names of a <see cref="ObjectSchema" />.
    /// </summary>
    [DataContract]
    public class ObjectLabels
    {
        /// <summary>
        /// Gets or sets the display name to use for one instance of the object.
        /// </summary>
        [DataMember]
        public string Singular { get; set; }

        /// <summary>
        /// Gets or sets the display name to use for multiple of the object.
        /// </summary>
        [DataMember]
        public string Plural { get; set; }
    }
}