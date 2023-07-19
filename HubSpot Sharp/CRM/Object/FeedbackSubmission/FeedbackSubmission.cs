// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeedbackSubmission.cs" company="">
//   
// </copyright>
// <summary>
//   The feedback submission.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.Object.FeedbackSubmission
{
    /// <summary>
    /// The feedback submission.
    /// </summary>
    [AssociationId("FEEDBACKSUBMISSION")]
    [ApiPathName("feedback_submissions")]
    [DataContract]
    public class FeedbackSubmission : HubSpotObject
    {
        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [DataMember(Name = "hs_content")]
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the ingestion id.
        /// </summary>
        [DataMember(Name = "hs_ingestion_id")]
        public string IngestionId { get; set; }

        /// <summary>
        /// Gets or sets the response group.
        /// </summary>
        [DataMember(Name = "hs_response_group")]
        public string ResponseGroup { get; set; }

        /// <summary>
        /// Gets or sets the submission name.
        /// </summary>
        [DataMember(Name = "hs_submission_name")]
        public string SubmissionName { get; set; }

        /// <summary>
        /// Gets or sets the channel.
        /// </summary>
        [DataMember(Name = "hs_survey_channel")]
        public string Channel { get; set; }

        /// <summary>
        /// Gets or sets the survey id.
        /// </summary>
        [DataMember(Name = "hs_survey_id")]
        public long SurveyId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [DataMember(Name = "hs_survey_name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        [DataMember(Name = "hs_survey_type")]
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        [DataMember(Name = "hs_value")]
        public int Value { get; set; }
    }
}