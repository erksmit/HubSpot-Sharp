using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.UserProvisioning
{
    public class UserProvisioningApi
    {
        private readonly HubSpotClient client;

        public UserProvisioningApi(HubSpotClient client)
        {
            this.client = client;
        }

        public async Task<ListResult<User>> GetAll(string? after = null, int limit = 100)
        {
            const string Path = "/settings/v3/users/";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
            {
                options.AddParam("after", after);
            }

            return await client.Execute<ListResult<User>>(options);
        }

        public async Task<User> Add(User user)
        {
            const string Path = "/settings/v3/users/";
            return await client.Execute<User>(Path, HttpMethod.Post, user);
        }

        public async Task<User> Retrieve(string id, bool isEmail = false)
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path);
            if (isEmail)
                options.AddParam("idProperty", "EMAIL");
            return await client.Execute<User>(options);
        }

        public async Task<User> Modify(User user, string id, bool isEmail = false)
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path, HttpMethod.Put, user);
            if (isEmail)
                options.AddParam("idProperty", "EMAIL");
            return await client.Execute<User>(options);

        }

        public async Task Remove(string id, bool isEmail = false)
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path, HttpMethod.Delete);
            if (isEmail)
                options.AddParam("idProperty", "EMAIL");
            await client.Execute(options);
        }

        public async Task<ListResult<T>> GetRoles<T>() where T : Role
        {
            const string Path = "/settings/v3/users/roles";
            return await client.Execute<ListResult<T>>(Path);
        }

        public async Task<ListResult<Team>> GetTeams()
        {
            const string Path = "/settings/v3/users/roles";
            return await client.Execute<ListResult<Team>>(Path);
        }
    }
}
