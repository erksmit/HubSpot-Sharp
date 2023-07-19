// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DailyUsage.cs" company="">
//   
// </copyright>
// <summary>
//   The daily usage.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{
    /// <summary>
    /// The daily usage.
    /// </summary>
    [DataContract]
    public class DailyUsage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DailyUsage"/> class.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        /// <param name="usageLimit">
        /// The usage limit.
        /// </param>
        /// <param name="currentUsage">
        /// The current usage.
        /// </param>
        /// <param name="collectedAt">
        /// The collected at.
        /// </param>
        /// <param name="fetchStatus">
        /// The fetch status.
        /// </param>
        /// <param name="resetsAt">
        /// The resets at.
        /// </param>
        [JsonConstructor]
        internal DailyUsage(
            string name,
            long usageLimit,
            long currentUsage,
            DateTime collectedAt,
            string fetchStatus,
            DateTime resetsAt)
        {
            Name = name;
            UsageLimit = usageLimit;
            CurrentUsage = currentUsage;
            CollectedAt = collectedAt;
            FetchStatus = fetchStatus;
            ResetsAt = resetsAt;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        [DataMember]
        public string Name { get; }

        /// <summary>
        /// Gets the usage limit.
        /// </summary>
        [DataMember]
        public long UsageLimit { get; }

        /// <summary>
        /// Gets the current usage.
        /// </summary>
        [DataMember]
        public long CurrentUsage { get; }

        /// <summary>
        /// Gets the collected at.
        /// </summary>
        [DataMember]
        public DateTime CollectedAt { get; }

        /// <summary>
        /// Gets the fetch status.
        /// </summary>
        [DataMember]
        public string FetchStatus { get; }

        /// <summary>
        /// Gets the resets at.
        /// </summary>
        [DataMember]
        public DateTime ResetsAt { get; }
    }
}