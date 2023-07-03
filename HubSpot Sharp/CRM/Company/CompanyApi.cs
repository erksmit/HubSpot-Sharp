// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyApi.cs" company="">
//   
// </copyright>
// <summary>
//   The company api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.CRM.Company
{
    /// <summary>
    /// The company api.
    /// </summary>
    public class CompanyApi : CrmBaseApi<Company>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompanyApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public CompanyApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}