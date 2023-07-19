// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectByPropertiesOptions.cs" company="">
//   
// </copyright>
// <summary>
//   The select by properties options.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.Options
{
    /// <summary>
    /// The request form for a Select by unique property request
    /// </summary>
    [DataContract]
    public class SelectByPropertiesOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectByPropertiesOptions" /> class.
        /// </summary>
        public SelectByPropertiesOptions()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectByPropertiesOptions"/> class.
        /// </summary>
        /// <param name="idProperty">
        /// the name of the unique property that will be used to identify the records.
        /// </param>
        /// <param name="inputs">
        /// the unique property values to read the records of.
        /// </param>
        public SelectByPropertiesOptions(string idProperty, IEnumerable<string> inputs)
        {
            IdProperty = idProperty;
            Inputs = inputs.Select(i => new IdInput(i)).ToList();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectByPropertiesOptions"/> class.
        /// </summary>
        /// <param name="idProperty">
        /// the name of the unique property that will be used to identify the records.
        /// </param>
        /// <param name="inputs">
        /// the unique property values to read the records of.
        /// </param>
        /// <param name="propertiesToRead">
        /// The properties to read.
        /// </param>
        public SelectByPropertiesOptions(string idProperty, IEnumerable<string> inputs, IList<string> propertiesToRead)
        {
            IdProperty = idProperty;
            Inputs = inputs.Select(i => new IdInput(i)).ToList();
            PropertiesToRead = propertiesToRead;
        }

        /// <summary>
        /// Gets or sets the object properties that will be read.
        /// </summary>
        [DataMember(Name = "properties")]
        public IList<string> PropertiesToRead { get; set; }

        /// <summary>
        /// Gets or sets the name of the unique property that will be used to identify the records.
        /// </summary>
        [DataMember]
        public string IdProperty { get; set; }

        /// <summary>
        /// Gets or sets the unique property values to read the records of.
        /// </summary>
        [DataMember]
        public IList<IdInput> Inputs { get; set; }
    }
}