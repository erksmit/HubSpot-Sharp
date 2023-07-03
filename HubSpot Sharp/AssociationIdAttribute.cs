// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectTypeIdAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The object id attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Reflection;

namespace HubSpot_Sharp
{
    /// <summary>
    /// The object type id of a HubSpot object type
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AssociationIdAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationIdAttribute"/> class.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public AssociationIdAttribute(string value)
        {
            Value = value;
        }

        /// <summary>
        /// Gets the value of the Id.
        /// </summary>
        public string Value { get; }

        public static string GetId<T>()
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<AssociationIdAttribute>();
            return attribute?.Value;
        }
    }
}