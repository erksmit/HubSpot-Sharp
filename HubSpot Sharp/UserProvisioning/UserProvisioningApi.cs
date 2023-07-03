using System.Runtime.Serialization;

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

        public ListResult<User> GetAll(string? after = null, int limit = 100)
        {
            const string Path = "/settings/v3/users/";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if(after != null)
            {
                options.AddParam("after", after);
            }

            return client.Execute<ListResult<User>>(options);
        }

        public User Add(User user)
        {
            const string Path = "/settings/v3/users/";
            return client.Execute<User>(Path, HttpMethod.Post, user);
        }

        public User Retrieve(string id, bool isEmail = false)
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path);
            if(isEmail)
                options.AddParam("idProperty", "EMAIL");
            return client.Execute<User>(options);
        }

        public User Modify(User user, string id, bool isEmail = false) 
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path, HttpMethod.Put, user);
            if(isEmail)
                options.AddParam("idProperty", "EMAIL");
            return client.Execute<User>(options);

        }

        public void Remove(string id, bool isEmail = false) 
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path, HttpMethod.Delete);
            if(isEmail)
                options.AddParam("idProperty", "EMAIL");
            client.Execute(options);
        }

        public ListResult<T> GetRoles<T>() where T : Role, new()
        {
            const string Path = "/settings/v3/users/roles";
            return client.Execute<ListResult<T>>(Path);
        }

        public ListResult<Team> GetTeams()
        {
            const string Path = "/settings/v3/users/roles";
            return client.Execute<ListResult<Team>>(Path);
        }
    }
}
