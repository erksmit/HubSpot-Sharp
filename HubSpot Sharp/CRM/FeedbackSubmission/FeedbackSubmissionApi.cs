using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.FeedbackSubmission
{
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class FeedbackSubmissionApi
    {
        private readonly HubSpotClient client;
        public FeedbackSubmissionApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<Association> GetAssociations(long feedbackSubmissionId, string toObjectType)
        {
            var path = $"/crm/v4/objects/feedback_submissions/{feedbackSubmissionId}/associations/{toObjectType}";
            return client.Execute<ListResult<Association>>(path);
        }

        public void Associate(long feedbackSubmissionId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/feedback_submissions/{feedbackSubmissionId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Put);
        }

        public void RemoveAssociation(long feedbackSubmissionId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/feedback_submissions/{feedbackSubmissionId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Delete);
        }

        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : FeedbackSubmission, new()
        {
            const string Path = "/crm/v3/objects/feedback_submissions";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        public T Create<T>(T obj) where T : FeedbackSubmission, new()
        {
            const string Path = "/crm/v3/objects/feedback_submissions";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(Path, Method.Post, pack).Unpack();
        }

        public T Read<T>(long id)
            where T : FeedbackSubmission, new()
        {
            var path = $"/crm/v3/objects/feedback_submissions/{id}";
            return this.client.Execute<PropertyBag<T>>(path).Unpack();
        }

        public T Update<T>(T obj)
            where T : FeedbackSubmission, new()
        {
            var path = $"/crm/v3/objects/feedback_submissions/{obj.Id}";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        public void Archive(long id)
        {
            var path = $"/crm/v3/objects/feedback_submissions/{id}";
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(SelectByPropertiesOptions inputs)
        {
            const string path = "/crm/v3/objects/feedback_submissions/batch/archive";
            this.client.Execute(path, Method.Post, inputs);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> inputs)
            where T : FeedbackSubmission, new()
        {
            const string path = "/crm/v3/objects/feedback_submissions/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, inputs);
        }

        /// <summary>
        /// Updates a batch of feedback_submissions.
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> feedbackSubmissions)
            where T : FeedbackSubmission, new()
        {
            string path = "/crm/v3/objects/feedback_submissions/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, feedbackSubmissions);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> feedbackSubmissions)
            where T : FeedbackSubmission, new() =>
            this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(feedbackSubmissions)));

        /// <summary>
        /// Gets a batch of feedback_submissions via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : FeedbackSubmission, new()
        {
            return this.client.Execute<BatchResult<PropertyBag<T>>>("/crm/v3/objects/feedback_submissions/batch/read", Method.Post, options);
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : FeedbackSubmission, new()
        {
            string path = "/crm/v3/objects/feedback_submissions/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}
