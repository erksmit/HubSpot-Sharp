using HubSpot_Sharp.Intermediates;

namespace HubSpot_Sharp.CRM.Deal
{
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class DealApi
    {
        private readonly HubSpotClient client;
        public DealApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<Association> GetAssociations(long dealId, string toObjectType)
        {
            var path = $"/crm/v4/objects/deals/{dealId}/associations/{toObjectType}";
            return client.Execute<ListResult<Association>>(path);
        }

        public void Associate(long dealId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/deals/{dealId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Put);
        }

        public void RemoveAssociation(long dealId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/deals/{dealId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Delete);
        }

        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : Deal, new()
        {
            const string Path = "/crm/v3/objects/deals";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        public T Create<T>(T obj) where T : Deal, new()
        {
            const string Path = "/crm/v3/objects/deals";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(Path, Method.Post, pack).Unpack();
        }

        public T Read<T>(long id)
            where T : Deal, new()
        {
            var path = $"/crm/v3/objects/deals/{id}";
            return this.client.Execute<PropertyBag<T>>(path).Unpack();
        }

        public T Update<T>(T obj)
            where T : Deal, new()
        {
            var path = $"/crm/v3/objects/deals/{obj.Id}";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        public void Archive(long id)
        {
            var path = $"/crm/v3/objects/deals/{id}";
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(SelectByPropertiesOptions inputs)
        {
            const string path = "/crm/v3/objects/deals/batch/archive";
            this.client.Execute(path, Method.Post, inputs);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> inputs)
            where T : Deal, new()
        {
            const string path = "/crm/v3/objects/deals/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, inputs);
        }

        /// <summary>
        /// Updates a batch of deals.
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> deals)
            where T : Deal, new()
        {
            string path = "/crm/v3/objects/deals/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, deals);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> deals)
            where T : Deal, new() =>
            this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(deals)));

        /// <summary>
        /// Gets a batch of deals via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : Deal, new()
        {
            return this.client.Execute<BatchResult<PropertyBag<T>>>("/crm/v3/objects/deals/batch/read", Method.Post, options);
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : Deal, new()
        {
            string path = "/crm/v3/objects/deals/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}
