// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedbackSubmissionApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The FeedbackSubmission api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Object;

namespace HubSpot_Sharp.CRM.FeedbackSubmission
{
    /// <summary>
    /// The FeedbackSubmission api.
    /// </summary>
    public class FeedbackSubmissionApi : CrmObjectBaseApi<FeedbackSubmission>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackSubmissionApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public FeedbackSubmissionApi(HubSpotClient client)
            : base(client)
        {
        }
    }
}