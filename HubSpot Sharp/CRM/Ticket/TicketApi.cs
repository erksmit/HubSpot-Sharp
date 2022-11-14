namespace HubSpot_Sharp.CRM.Ticket
{
    using System.Collections.Generic;

    using HubSpot_Sharp;
    using HubSpot_Sharp.Intermediates;
    using HubSpot_Sharp.Options;
    using HubSpot_Sharp.Search;

    using RestSharp;

    public class TicketApi
    {
        private readonly HubSpotClient client;

        public TicketApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<Association> GetAssociations(long ticketId, string toObjectType, int limit = 500, string? after = null)
        {
            var path = $"/crm/v4/objects/tickets/{ticketId}/associations/{toObjectType}";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit.ToString());
            if (after != null)
                options.AddParam("after", after);

            return this.client.Execute<ListResult<Association>>(options);
        }

        public void Associate(long ticketId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/tickets/{ticketId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Put);
        }

        public void RemoveAssociation(long ticketId, string toObjectType, long toObjectId)
        {
            var path = $"/crm/v4/objects/tickets/{ticketId}/associations/{toObjectType}/{toObjectId}";
            this.client.Execute(path, Method.Delete);
        }

        public ListResult<PropertyBag<T>> List<T>(int limit = 10, string? after = null, IList<string>? properties = null) where T : Ticket, new()
        {
            const string Path = "/crm/v3/objects/tickets";
            var options = new RequestOptions(Path);
            options.AddParam("limit", limit);
            if (after != null)
                options.AddParam("after", after);
            if (properties != null)
                options.AddParam("properties", string.Join(",", properties));
            return this.client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        public T Create<T>(T obj) where T : Ticket, new()
        {
            const string Path = "/crm/v3/objects/tickets";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(Path, Method.Post, pack).Unpack();
        }

        public T Read<T>(long id)
            where T : Ticket, new()
        {
            var path = $"/crm/v3/objects/tickets/{id}";
            return this.client.Execute<PropertyBag<T>>(path, Method.Get).Unpack();
        }

        public T Update<T>(T obj)
            where T : Ticket, new()
        {
            var path = $"/crm/v3/objects/tickets/{obj.Id}";
            using var pack = PropertyBag<T>.Pack(obj);
            return this.client.Execute<PropertyBag<T>>(path, Method.Patch, pack).Unpack();
        }

        public void Archive(long id)
        {
            var path = $"/crm/v3/objects/tickets/{id}";
            this.client.Execute(path, Method.Delete);
        }

        public void ArchiveBatch(SelectByPropertiesOptions inputs)
        {
            const string path = "/crm/v3/objects/tickets/batch/archive";
            this.client.Execute(path, Method.Post, inputs);
        }

        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> inputs)
            where T : Ticket, new()
        {
            const string path = "/crm/v3/objects/tickets/batch/create";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, inputs);
        }

        /// <summary>
        /// Updates a batch of tickets.
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the result of the update.</returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> tickets)
            where T : Ticket, new()
        {
            string path = "/crm/v3/objects/tickets/batch/update";
            return this.client.Execute<BatchResult<PropertyBag<T>>>(path, Method.Post, tickets);
        }

        /// <inheritdoc cref="UpdateBatch{T}" />
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> tickets)
            where T : Ticket, new() =>
            this.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(tickets)));

        /// <summary>
        /// Gets a batch of tickets via a unique property
        /// </summary>
        /// <returns>A <see cref="BatchResult{T}" /> containing the retrieved results.</returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : Ticket, new()
        {
            return this.client.Execute<BatchResult<PropertyBag<T>>>("/crm/v3/objects/tickets/batch/read", Method.Post, options);
        }

        public SearchResults<T> Search<T>(SearchOptions options)
            where T : Ticket, new()
        {
            string path = "/crm/v3/objects/tickets/search";
            var requestOptions = new RequestOptions(path, Method.Post, options, RateLimitOptions.RetrySearch);
            return this.client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}