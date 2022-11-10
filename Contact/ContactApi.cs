namespace HubSpot_Sharp.Contact
{
    using System.Collections.Generic;

    using HubSpot_Sharp;

    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class ContactApi
    {
        private readonly HubSpotClient client;

        public ContactApi(HubSpotClient client)
        {
            this.client = client;
        }

        public AssociationsList GetAssociations(long contactId, string toObjectType, int limit = 500, string? after = null)
        {
            var path = $"/crm/v4/objects/contacts/{contactId}/associations/{toObjectType}";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit.ToString());
            if (after != null)
                options.AddParam("after", after);

            return client.Execute<AssociationsList>(options);
        }

        public void Associate(long contactId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/contacts/{contactId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Put);
        }

        public void RemoveAssociation(long contactId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/contacts/{contactId}/associations/{toObjectType}/{toObjectId}";
            client.Execute(path, Method.Delete);
        }

        public ListResult<T> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : BaseContact, new()
        {
            const string Path = "/crm/v3/objects/contacts";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return client.Execute<ListResult<T>>(options);
        }

        public T Create<T>(T obj) where T : BaseContact, new()
        {
            const string Path = "/crm/v3/objects/contacts";
            return client.Execute<PropertyBag<T>>(Path, Method.Post, PropertyBag<T>.Pack(obj)).Unpack();
        }

        public T Read<T>(long id)
            where T : BaseContact, new()
        {
            var path = $"/crm/v3/objects/contacts/{id}";
            return client.Execute<PropertyBag<T>>(path, Method.Get).Unpack();
        }

        public T Update<T>(T obj)
            where T : BaseContact, new()
        {
            var path = $"/crm/v3/objects/contacts/{obj.Id}";
            return client.Execute<PropertyBag<T>>(path, Method.Patch, PropertyBag<T>.Pack(obj)).Unpack();
        }

        public void Archive(long id)
        {
            var path = $"/crm/v3/objects/contacts/{id}";
            client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(BatchIdInputs inputs)
        {
            const string path = "/crm/v3/objects/contacts/batch/archive";
            client.Execute(path, Method.Post, inputs);
        }

        public BatchResult<T> CreateBatch<T>(BatchInputs<T> inputs)
            where T : BaseContact, new()
        {
            const string path = "/crm/v3/objects/contacts/batch/create";
            return client.Execute<BatchResult<T>>(path, Method.Post, inputs);
        }

        /// <summary>
        /// Updates a batch of contacts.
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<T> UpdateBatch<T>(BatchInputs<T> contacts)
            where T : BaseContact, new()
        {
            string path = "/crm/v3/objects/contacts/batch/update";
            return client.Execute<BatchResult<T>>(path, Method.Post, contacts);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<T> UpdateBatch<T>(IList<T> contacts)
            where T : BaseContact, new() =>
            UpdateBatch(new BatchInputs<T>(contacts));

        /// <summary>
        /// Gets a batch of contacts via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<T> ReadByProperties<T>(BatchIdInputs options)
            where T : BaseContact, new()
        {
            return client.Execute<BatchResult<T>>("/crm/v3/objects/contacts/batch/read", Method.Post, options);
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : BaseContact, new()
        {
            string path = "/crm/v3/objects/contacts/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}