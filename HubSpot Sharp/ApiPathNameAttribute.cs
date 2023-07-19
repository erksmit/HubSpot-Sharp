// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiPathNameAttribute.cs" company="">
//   
// </copyright>
// <summary>
//   The api path name attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Reflection;

namespace HubSpot_Sharp
{
    /// <summary>
    /// The api path name attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    internal class ApiPathNameAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiPathNameAttribute"/> class.
        /// </summary>
        /// <param name="segment">
        /// The segment.
        /// </param>
        public ApiPathNameAttribute(string segment)
        {
            Segment = segment;
        }

        /// <summary>
        /// Gets the segment.
        /// </summary>
        public string Segment { get; }

        /// <summary>
        /// Returns the api path name attribute's value if defined.
        /// </summary>
        /// <typeparam name="T">The type to get the path segment for.</typeparam>
        /// <returns>The path segment, or null if it was not defined.</returns>
        public static string? GetSegment<T>()
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<ApiPathNameAttribute>();
            return attribute?.Segment;
        }
    }
}