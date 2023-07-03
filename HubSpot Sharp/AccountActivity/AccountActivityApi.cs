using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.AccountActivity
{
    public class AccountActivityApi
    {
        private readonly HubSpotClient client;

        public AccountActivityApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<DailyUsage> GetDailyUsage(string hapiKey)
        {
            var options = new RequestOptions("/account-info/v3/api-usage/daily", tokenLess: true);
            options.AddParam("hapikey", hapiKey);
            return client.Execute<ListResult<DailyUsage>>(options);
        }

        public AccountDetails GetAccountDetails()
        {
            const string Path = "/account-info/v3/details";
            return client.Execute<AccountDetails>(Path);
        }

        public ListResult<LoginActivity> GetLoginActivity(long userId, string? after = null, int limit = 100)
        {
            const string Path = "/account-info/v3/activity/login";
            var options = new RequestOptions(Path);
            options.AddParam("userId", userId);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);

            return client.Execute<ListResult<LoginActivity>>(options);
        }

        public ListResult<SecurityActivity> GetSecurityActivity(long userId, string? after = null, int limit = 100)
        {
            const string Path = "/account-info/v3/activity/security";
            var options = new RequestOptions(Path);
            options.AddParam("userId", userId);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);

            return client.Execute<ListResult<SecurityActivity>>(options);
        }
    }
}
