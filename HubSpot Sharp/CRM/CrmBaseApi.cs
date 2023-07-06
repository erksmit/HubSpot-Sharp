using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;
using HubSpot_Sharp.Search;

namespace HubSpot_Sharp.CRM
{
    public abstract class CrmBaseApi<THubType> where THubType : HubSpotObject, new()
    {
        /// <summary>
        /// The HubSpot client to make requests with.
        /// </summary>
        private readonly HubSpotClient client;

        private readonly string pathSegment;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrmBaseApi{THubType}"/> class with the specified type.
        /// </summary>
        /// <param name="client">
        /// The HubSpot client to make requests with.
        /// </param>
        internal CrmBaseApi(HubSpotClient client)
        {
            this.client = client;
            pathSegment = ApiPathNameAttribute.GetSegment<THubType>();
        }

        /// <summary>
        /// Gets the associations of a <typeparamref name="THubType"/>.
        /// </summary>
        /// <param name="objectId">
        /// The id of the <typeparamref name="THubType"/>.
        /// </param>
        /// <param name="toObjectType">
        /// The type id of the associated object.
        /// </param>
        /// <returns>
        /// A list of associations for the <typeparamref name="THubType"/> instance.
        /// </returns>
        public ListResult<Association> GetAssociations(long objectId, string toObjectType)
        {
            var path = $"/crm/v3/objects/{pathSegment}/{objectId}/associations/{toObjectType}";
            return client.Execute<ListResult<Association>>(path);
        }

        /// <inheritdoc cref="GetAssociations(long, string)" />
        public ListResult<Association> GetAssociations<T>(long objectId) where T : HubSpotObject
        {
            return GetAssociations(objectId, AssociationIdAttribute.GetId<T>());
        }

        /// <summary>
        /// Associate a <typeparamref name="THubType"/> with another object
        /// </summary>
        /// <param name="objectId">
        /// The id of the object.
        /// </param>
        /// <param name="toObjectType">
        /// The type of the object to associate to.
        /// </param>
        /// <param name="toObjectId">
        /// The id of the object to associate to.
        /// </param>
        /// <param name="associationType">
        /// The name of the association.
        /// </param>
        public void Associate(
            long objectId,
            string toObjectType,
            long toObjectId,
            string associationType)
        {
            var path =
                $"/crm/v3/objects/{pathSegment}/{objectId}/associations/{toObjectType}/{toObjectId}/{associationType}";
            client.Execute(path, HttpMethod.Put);
        }

        /// <inheritdoc cref="Associate(long, string, long, string)"/>
        public void Associate<TToObject>(
            long objectId,
            long toObjectId,
            string associationType) where TToObject : HubSpotObject
        {
            Associate(objectId, AssociationIdAttribute.GetId<TToObject>(), toObjectId, associationType);
        }
        
        /// <inheritdoc cref="Associate(long, string, long, string)"/>
        public void Associate<TToObject>(THubType fromObject, TToObject toObject, string associationType) where TToObject: HubSpotObject
        {
            Associate<TToObject>((long)fromObject.Id!, (long)toObject.Id!, associationType);
        }


        /// <summary>
        /// Removes an association between a <typeparamref name="THubType"/> and another object.
        /// </summary>
        /// <param name="objectId">
        /// The id of the object.
        /// </param>
        /// <param name="toObjectType">
        /// The type of the object to associate to.
        /// </param>
        /// <param name="toObjectId">
        /// The id of the object to associate to.
        /// </param>
        /// <param name="associationType">
        /// The name of the association.
        /// </param>
        public void RemoveAssociation(
            long objectId,
            string toObjectType,
            long toObjectId,
            string associationType)
        {
            var path =
                $"/crm/v3/objects/{pathSegment}/{objectId}/associations/{toObjectType}/{toObjectId}/{associationType}";
            client.Execute(path, HttpMethod.Delete);
        }

        /// <inheritdoc cref="RemoveAssociation(long, string, long, string)"/>
        public void RemoveAssociation<TToObject>(
            long objectId,
            long toObjectId,
            string associationType) where TToObject : HubSpotObject
        {
            RemoveAssociation(objectId, AssociationIdAttribute.GetId<TToObject>(), toObjectId, associationType);
        }

        /// <inheritdoc cref="Associate(long, string, long, string)"/>
        public void RemoveAssociation<TToObject>(THubType fromObject, TToObject toObject, string associationType) where TToObject: HubSpotObject
        {
            RemoveAssociation<TToObject>((long)fromObject.Id!, (long)toObject.Id!, associationType);
        }

        /// <summary>
        /// Creates a <typeparamref name="T"/> of the specified type
        /// </summary>
        /// <typeparam name="T">The <typeparamref name="THubType"/>'s specific type
        /// </typeparam>
        /// <param name="obj">
        /// The object to create.
        /// </param>
        /// <returns>
        /// The created <typeparamref name="T"/>
        /// </returns>
        public T Create<T>(T obj) where T : THubType, new()
        {
            var path = "/crm/v3/objects/" + pathSegment;
            var pack = new PropertyBag<T>(obj);
            return client.Execute<PropertyBag<T>>(path, HttpMethod.Post, pack).GetProperties();
        }

        /// <summary>
        /// Read a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="objectId">
        /// The id of the object.
        /// </param>
        /// <typeparam name="T">The object type to read.
        /// </typeparam>
        /// <returns>
        /// The retrieved <typeparamref name="T"/>
        /// </returns>
        public T Read<T>(long objectId)
            where T : THubType, new()
        {
            var path = $"/crm/v3/objects/{pathSegment}/{objectId}";
            return client.Execute<PropertyBag<T>>(path).GetProperties();
        }

        /// <summary>
        /// List all <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="limit">
        /// How many objects to read.
        /// </param>
        /// <param name="after">
        /// The offset to begin reading at.
        /// </param>
        /// <param name="properties">
        /// The properties to return.
        /// </param>
        /// <typeparam name="T">The type of the object to read.
        /// </typeparam>
        /// <returns>
        /// A list of the retrieved objects.
        /// </returns>
        public ListResult<PropertyBag<T>> List<T>(
            int limit = 100,
            string? after = null,
            IList<string>? properties = null)
            where T : THubType, new()
        {
            var path = $"/crm/v3/objects/{pathSegment}";
            var options = new RequestOptions(path);
            options.AddParam("limit", limit);
            if (after != null)
            {
                options.AddParam("after", after);
            }

            if (properties != null)
            {
                options.AddParam("properties", string.Join(",", properties));
            }

            return client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        /// <summary>
        /// Update a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to update.
        /// </param>
        /// <typeparam name="T">The type of the <typeparamref name="THubType"/> to update
        /// </typeparam>
        /// <returns>
        /// The updated object.
        /// </returns>
        public T Update<T>(T obj)
            where T : THubType, new()
        {
            var path = $"/crm/v3/objects/{pathSegment}/{obj.Id}";
            var pack = new PropertyBag<T>(obj);
            return client.Execute<PropertyBag<T>>(path, HttpMethod.Patch, pack).GetProperties();
        }

        /// <summary>
        /// Archives a <typeparamref name="THubType"/> object, it will be deleted after 90 days.
        /// </summary>
        /// <param name="objectId">
        /// The id of the object to archive.
        /// </param>
        public void Archive(long objectId)
        {
            var path = $"/crm/v3/objects/{pathSegment}/{objectId}";
            client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// Archives a batch of <typeparamref name="THubType"/> objects, they will be deleted in 90 days.
        /// </summary>
        /// <param name="inputs">
        /// The id's of the objects to archive.
        /// </param>
        public void ArchiveBatch(ListInputs<IdInput> inputs)
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/archive";
            client.Execute(path, HttpMethod.Post, inputs);
        }


        /// <summary>
        /// Creates a batch of <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects">
        /// The objects to create.
        /// </param>
        /// <typeparam name="T">The type of the objects.
        /// </typeparam>
        /// <returns>
        /// A list of the created objects.
        /// </returns>
        public BatchResult<PropertyBag<T>> CreateBatch<T>(ListInputs<PropertyBag<T>> objects)
            where T : THubType, new()
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/create";
            return client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, objects);
        }
        /// <summary>
        /// Creates a batch of <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects">
        /// The objects to create.
        /// </param>
        /// <typeparam name="T">The type of the objects.
        /// </typeparam>
        /// <returns>
        /// A list of the created objects.
        /// </returns>
        public BatchResult<PropertyBag<T>> CreateBatch<T>(IList<T> objects)
            where T : THubType, new()
        {
            return CreateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(objects)));
        }

        /// <summary>
        /// Reads a set of <typeparamref name="T"/> objects using a set of unique property values.
        /// </summary>
        /// <param name="options">
        /// The selection parameters used to identify the objects.
        /// </param>
        /// <typeparam name="T">The type of the <typeparamref name="THubType"/>.
        /// </typeparam>
        /// <returns>
        /// A list of the retrieved objects.
        /// </returns>
        public BatchResult<PropertyBag<T>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : THubType, new()
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/read";
            return client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, options);
        }

        /// <summary>
        /// Updates a batch of <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects">
        /// The objects to update.
        /// </param>
        /// <typeparam name="T">The type of the objects.
        /// </typeparam>
        /// <returns>
        /// A list of the updated objects.
        /// </returns>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(ListInputs<PropertyBag<T>> objects)
            where T : THubType, new()
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/update";
            return client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, objects);
        }

        /// <inheritdoc cref="UpdateBatch{T}(ListInputs{PropertyBag{T}})"/>
        public BatchResult<PropertyBag<T>> UpdateBatch<T>(IList<T> objects)
            where T : THubType, new()
        {
            return UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(objects)));
        }

        /// <summary>
        /// Searches for <typeparamref name="T"/ objects.
        /// </summary>
        /// <param name="options">
        /// The search options.
        /// </param>
        /// <typeparam name="T">The type of the <typeparamref name="THubType"/>.
        /// </typeparam>
        /// <returns>
        /// A list of search results.
        /// </returns>
        public SearchResults<T> Search<T>(SearchOptions options)
            where T : THubType, new()
        {
            var path = $"/crm/v3/objects/{pathSegment}/search";
            var requestOptions = new RequestOptions(path, HttpMethod.Post, options, rateLimit: RateLimitOptions.RetrySearch);
            return client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}
