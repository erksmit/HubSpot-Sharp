// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeserializeOnlyAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   Marks that the property should only be deserialized and will never be serialized into json
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;

namespace HubSpot_Sharp.Serialization
{
    /// <summary>
    /// Indicates that the property should only be deserialized and will never be serialized into json
    /// </summary>
    public class DeserializeOnlyAttribute : Attribute
    {
    }
}