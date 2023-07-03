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
        /// Gets the segment.
        /// </summary>
        public string Segment { get; }

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

        public static string GetSegment<T>()
        {
            var type = typeof(T);
            var attribute = type.GetCustomAttribute<ApiPathNameAttribute>();
            return attribute?.Segment;
        }
    }
}