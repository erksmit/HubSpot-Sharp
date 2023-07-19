// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserProvisioningApi.cs" company="">
//   
// </copyright>
// <summary>
//   The user provisioning api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.UserProvisioning
{
    /// <summary>
    /// The user provisioning api.
    /// </summary>
    public class UserProvisioningApi
    {
        /// <summary>
        /// The client.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserProvisioningApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public UserProvisioningApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="after">
        /// The after.
        /// </param>
        /// <param name="limit">
        /// The limit.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
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

        /// <summary>
        /// The add.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<User> Add(User user)
        {
            const string Path = "/settings/v3/users/";
            return await client.Execute<User>(Path, HttpMethod.Post, user);
        }

        /// <summary>
        /// The retrieve.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="isEmail">
        /// The is email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<User> Retrieve(string id, bool isEmail = false)
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path);
            if (isEmail)
            {
                options.AddParam("idProperty", "EMAIL");
            }

            return await client.Execute<User>(options);
        }

        /// <summary>
        /// The modify.
        /// </summary>
        /// <param name="user">
        /// The user.
        /// </param>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="isEmail">
        /// The is email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<User> Modify(User user, string id, bool isEmail = false)
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path, HttpMethod.Put, user);
            if (isEmail)
            {
                options.AddParam("idProperty", "EMAIL");
            }

            return await client.Execute<User>(options);
        }

        /// <summary>
        /// The remove.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="isEmail">
        /// The is email.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Remove(string id, bool isEmail = false)
        {
            var path = $"/settings/v3/users/{id}";
            var options = new RequestOptions(path, HttpMethod.Delete);
            if (isEmail)
            {
                options.AddParam("idProperty", "EMAIL");
            }

            await client.Execute(options);
        }

        /// <summary>
        /// The get roles.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<T>> GetRoles<T>()
            where T : Role
        {
            const string Path = "/settings/v3/users/roles";
            return await client.Execute<ListResult<T>>(Path);
        }

        /// <summary>
        /// The get teams.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<ListResult<Team>> GetTeams()
        {
            const string Path = "/settings/v3/users/roles";
            return await client.Execute<ListResult<Team>>(Path);
        }
    }
}