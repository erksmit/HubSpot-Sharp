namespace HubSpot_Sharp.CRM.Custom
{
    using System.Runtime.Serialization;

    /// <summary>
    /// Display names of a <see cref="ObjectSchema" />.
    /// </summary>
    [DataContract]
    public class ObjectLabels
    {
        /// <summary>
        /// The display name to use for one instance of the object.
        /// </summary>
        [DataMember(Name = "singular")]
        public string Singular { get; set; }

        /// <summary>
        /// The display name to use for multiple of the object.
        /// </summary>
        [DataMember(Name = "plural")]
        public string Plural { get; set; }
    }
}