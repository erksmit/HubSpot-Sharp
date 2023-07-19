// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountActivityApi.cs" company="">
//   
// </copyright>
// <summary>
//   The account activity api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.AccountActivity
{
    /// <summary>
    /// The account activity api.
    /// </summary>
    public class AccountActivityApi
    {
        /// <summary>
        /// The client.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountActivityApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public AccountActivityApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The get daily usage.
        /// </summary>
        /// <param name="hapiKey">
        /// The hapi key.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<DailyUsage>> GetDailyUsage(string hapiKey)
        {
            var options = new RequestOptions("/account-info/v3/api-usage/daily", tokenLess: true);
            options.AddParam("hapikey", hapiKey);
            return await client.Execute<ListResult<DailyUsage>>(options);
        }

        /// <summary>
        /// The get account details.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<AccountDetails> GetAccountDetails()
        {
            const string Path = "/account-info/v3/details";
            return await client.Execute<AccountDetails>(Path);
        }

        /// <summary>
        /// The get login activity.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="after">
        /// The after.
        /// </param>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<LoginActivity>> GetLoginActivity(
            long userId,
            string? after = null,
            int limit = 100)
        {
            const string Path = "/account-info/v3/activity/login";
            var options = new RequestOptions(Path);
            options.AddParam("userId", userId);
            options.AddParam("limit", limit);
            if (after != null)
            {
                options.AddParam("after", after);
            }

            return await client.Execute<ListResult<LoginActivity>>(options);
        }

        /// <summary>
        /// The get security activity.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="after">
        /// The after.
        /// </param>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<SecurityActivity>> GetSecurityActivity(
            long userId,
            string? after = null,
            int limit = 100)
        {
            const string Path = "/account-info/v3/activity/security";
            var options = new RequestOptions(Path);
            options.AddParam("userId", userId);
            options.AddParam("limit", limit);
            if (after != null)
            {
                options.AddParam("after", after);
            }

            return await client.Execute<ListResult<SecurityActivity>>(options);
        }
    }
}