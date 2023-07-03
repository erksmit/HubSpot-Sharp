// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HubSpotEnumerationAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   When applied the property will be serialized as a semicolon delimited string
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HubSpot_Sharp.Serialization
{
    /// <summary>
    /// Indicates that the property should be serialized as a semicolon delimited string using the <see cref="EnumerationConverter"/>.
    /// </summary>
    public class HubSpotEnumerationAttribute : Attribute
    {
    }
}