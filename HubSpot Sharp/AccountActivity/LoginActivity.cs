// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginActivity.cs" company="">
//   
// </copyright>
// <summary>
//   The login activity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

using Newtonsoft.Json;

namespace HubSpot_Sharp.AccountActivity
{
    /// <summary>
    /// The login activity.
    /// </summary>
    [DataContract]
    public class LoginActivity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginActivity"/> class.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="loginAt">
        /// The login at.
        /// </param>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="countryCode">
        /// The country code.
        /// </param>
        /// <param name="regionCode">
        /// The region code.
        /// </param>
        /// <param name="ipAddress">
        /// The ip address.
        /// </param>
        /// <param name="userAgent">
        /// The user agent.
        /// </param>
        /// <param name="loginSucceeded">
        /// The login succeeded.
        /// </param>
        [JsonConstructor]
        internal LoginActivity(
            string id,
            DateTime loginAt,
            long userId,
            string email,
            string countryCode,
            string regionCode,
            string ipAddress,
            string userAgent,
            bool loginSucceeded)
        {
            Id = id;
            LoginAt = loginAt;
            UserId = userId;
            Email = email;
            CountryCode = countryCode;
            RegionCode = regionCode;
            IpAddress = ipAddress;
            UserAgent = userAgent;
            LoginSucceeded = loginSucceeded;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        [DataMember]
        public string Id { get; }

        /// <summary>
        /// Gets the login at.
        /// </summary>
        [DataMember]
        public DateTime LoginAt { get; }

        /// <summary>
        /// Gets the user id.
        /// </summary>
        [DataMember]
        public long UserId { get; }

        /// <summary>
        /// Gets the email.
        /// </summary>
        [DataMember]
        public string Email { get; }

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

        /// <summary>
        /// Gets the ip address.
        /// </summary>
        [DataMember]
        public string IpAddress { get; }

        /// <summary>
        /// Gets the user agent.
        /// </summary>
        [DataMember]
        public string UserAgent { get; }

        /// <summary>
        /// Gets the login succeeded.
        /// </summary>
        [DataMember]
        public bool LoginSucceeded { get; }
    }
}