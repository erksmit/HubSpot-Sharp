// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SecurityActivity.cs" company="">
//   
// </copyright>
// <summary>
//   The security activity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{
    /// <summary>
    /// The security activity.
    /// </summary>
    [DataContract]
    public class SecurityActivity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SecurityActivity"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="createdAt">
        /// The created at.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="actingUser">
        /// The acting user.
        /// </param>
        /// <param name="objectId">
        /// The object id.
        /// </param>
        /// <param name="infoUrl">
        /// The info url.
        /// </param>
        /// <param name="ipAddress">
        /// The ip address.
        /// </param>
        /// <param name="countryCode">
        /// The country code.
        /// </param>
        /// <param name="regionCode">
        /// The region code.
        /// </param>
        [JsonConstructor]
        internal SecurityActivity(
            string id,
            DateTime createdAt,
            long userId,
            string type,
            string actingUser,
            string objectId,
            string infoUrl,
            string ipAddress,
            string countryCode,
            string regionCode)
        {
            Id = id;
            CreatedAt = createdAt;
            UserId = userId;
            Type = type;
            ActingUser = actingUser;
            ObjectId = objectId;
            InfoUrl = infoUrl;
            IpAddress = ipAddress;
            CountryCode = countryCode;
            RegionCode = regionCode;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [DataMember]
        public string Id { get; }

        /// <summary>
        /// Gets the created at.
        /// </summary>
        [DataMember]
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        [DataMember]
        public long UserId { get; }

        /// <summary>
        /// Gets the type.
        /// </summary>
        [DataMember]
        public string Type { get; }

        /// <summary>
        /// Gets the acting user.
        /// </summary>
        [DataMember]
        public string ActingUser { get; }

        /// <summary>
        /// Gets the object id.
        /// </summary>
        [DataMember]
        public string ObjectId { get; }

        /// <summary>
        /// Gets the info url.
        /// </summary>
        [DataMember]
        public string InfoUrl { get; }

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        [DataMember]
        public string IpAddress { get; }

        /// <summary>
        /// Gets the country code.
        /// </summary>
        [DataMember]
        public string CountryCode { get; }

        /// <summary>
        /// Gets the region code.
        /// </summary>
        [DataMember]
        public string RegionCode { get; }
    }
}