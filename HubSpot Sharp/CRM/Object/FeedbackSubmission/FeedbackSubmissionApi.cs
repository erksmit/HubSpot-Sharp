// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedbackSubmissionApi.cs" contact="" company="">
//   
// </copyright>
// <summary>
//   The FeedbackSubmission api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HubSpot_Sharp.CRM.Object.FeedbackSubmission
{
    /// <summary>
    /// The FeedbackSubmission api.
    /// </summary>
    public class FeedbackSubmissionApi : CrmContentApi<FeedbackSubmission>
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