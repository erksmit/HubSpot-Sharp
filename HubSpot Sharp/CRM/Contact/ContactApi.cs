namespace HubSpot_Sharp.CRM.Contact
{
    using System.Collections.Generic;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class ContactApi
    {
        private readonly HubSpotClient client;

        public ContactApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<Association> GetAssociations(long contactId, string toObjectType, int limit = 500, string? after = null)
        {
            var path = $"/crm/v4/objects/contacts/{contactId}/associations/{toObjectType}";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit.ToString());
            if (after != null)
                options.AddParam("after", after);

            return this.client.Execute<ListResult<Association>>(options);
        }

        public void Associate(long contactId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/contacts/{contactId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Put);
        }

        public void RemoveAssociation(long contactId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/contacts/{contactId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Delete);
        }

        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : Contact, new()
        {
            const string Path = "/crm/v3/objects/contacts";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return this.client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        public T Create<T>(T obj) where T : Contact, new()
        {
            const string Path = "/crm/v3/objects/contacts";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(Path, Method.Post, pack).Unpack();
        }

        public T Read<T>(long id)
            where T : Contact, new()
        {
            var path = $"/crm/v3/objects/contacts/{id}";
            return this.client.Execute<PropertyBag<T>>(path, Method.Get).Unpack();
        }

        public T Update<T>(T obj)
            where T : Contact, new()
        {
            var path = $"/crm/v3/objects/contacts/{obj.Id}";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        public void Archive(long id)
        {
            var path = $"/crm/v3/objects/contacts/{id}";
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(SelectByPropertiesOptions inputs)
        {
            const string path = "/crm/v3/objects/contacts/batch/archive";
            this.client.Execute(path, Method.Post, inputs);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> inputs)
            where T : Contact, new()
        {
            const string path = "/crm/v3/objects/contacts/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, inputs);
        }

        /// <summary>
        /// Updates a batch of contacts.
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> contacts)
            where T : Contact, new()
        {
            string path = "/crm/v3/objects/contacts/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, contacts);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> contacts)
            where T : Contact, new() =>
            this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(contacts)));

        /// <summary>
        /// Gets a batch of contacts via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : Contact, new()
        {
            return this.client.Execute<BatchResult<PropertyBag<T>>>("/crm/v3/objects/contacts/batch/read", Method.Post, options);
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : Contact, new()
        {
            string path = "/crm/v3/objects/contacts/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}