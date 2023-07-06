using System.Runtime.Serialization;

namespace HubSpot_Sharp.CRM.FeedbackSubmission
{
    
    [AssociationId("FEEDBACKSUBMISSION")]
    [ApiPathName("feedback_submissions")]
    [DataContract]
    public class FeedbackSubmission : HubSpotObject
    {
        [DataMember(Name = "hs_content")]
        public string Content { get; set; }
        
        [DataMember(Name = "hs_ingestion_id")]
        public string IngestionId { get; set; }
        
        [DataMember(Name = "hs_response_group")]
        public string ResponseGroup { get; set; }
        
        [DataMember(Name = "hs_submission_name")]
        public string SubmissionName { get; set; }
        
        [DataMember(Name = "hs_survey_channel")]
        public string Channel { get; set; }
        
        [DataMember(Name = "hs_survey_id")]
        public long SurveyId { get; set; }
        
        [DataMember(Name = "hs_survey_name")]
        public string Name { get; set; }
        
        [DataMember(Name = "hs_survey_type")]
        public string Type { get; set; }

        [DataMember(Name = "hs_value")]
        public int Value { get; set; }
    }
}
