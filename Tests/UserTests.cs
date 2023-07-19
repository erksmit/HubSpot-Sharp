// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserTests.cs" company="">
//   
// </copyright>
// <summary>
//   Tests the user provisioning api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.AccountActivity;
using HubSpot_Sharp.UserProvisioning;

namespace Tests
{
    /// <summary>
    /// Tests the user provisioning api.
    /// </summary>
    [TestClass]
    public class UserTests
    {
        /// <summary>
        /// The account activity api.
        /// </summary>
        private readonly AccountActivityApi accountActivityApi = Config.Api.AccountActivity;

        /// <summary>
        /// The user provisioning api.
        /// </summary>
        private readonly UserProvisioningApi userProvisioningApi = Config.Api.UserProvisioning;

        /// <summary>
        /// Tests getting some account information.
        /// </summary>
        /// <returns>
        /// The <see cref="void"/>.
        /// </returns>
        [TestMethod]
        public void AccountTest()
        {
            var details = accountActivityApi.GetAccountDetails();

            var all = userProvisioningApi.GetAll();
            var teams = userProvisioningApi.GetTeams();
            var roles = userProvisioningApi.GetRoles<Role>();
        }
    }
}