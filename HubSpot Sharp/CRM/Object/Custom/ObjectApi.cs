// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectApi.cs" company="">
//   
// </copyright>
// <summary>
//   The object api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Associations;
using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;
using HubSpot_Sharp.Search;

namespace HubSpot_Sharp.CRM.Object.Custom
{
    /// <summary>
    /// Contains functions for interacting with custom object endpoints.
    /// </summary>
    public class ObjectApi
    {
        /// <summary>
        /// The HubSpot client to make requests with.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectApi"/> class.
        /// The object api.
        /// </summary>
        /// <param name="client">
        /// The HubSpot client to make requests with.
        /// </param>
        public ObjectApi(HubSpotClient client)
        {
            this.client = client;
        }

        /// <summary>
        /// Gets the associations of a custom object.
        /// </summary>
        /// <param name="objectType">
        /// The type id of the object to get associations for.
        /// </param>
        /// <param name="objectId">
        /// The id of the custom object.
        /// </param>
        /// <param name="toObjectType">
        /// The type id of the associated object.
        /// </param>
        /// <returns>
        /// A list of associations.
        /// </returns>
        public async Task<ListResult<Association>> GetAssociations(
            string objectType,
            long objectId,
            string toObjectType)
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}/associations/{toObjectType}";
            return await client.Execute<ListResult<Association>>(path);
        }

        /// <inheritdoc cref="GetAssociations(string, long, string)" />
        public async Task<ListResult<Association>> GetAssociations<TToObject>(string objectType, long objectId)
            where TToObject : HubSpotObject
        {
            return await GetAssociations(objectType, objectId, AssociationIdAttribute.GetId<TToObject>());
        }

        /// <summary>
        /// Associate a custom object with another object
        /// </summary>
        /// <param name="objectType">
        /// The type of the custom object
        /// </param>
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
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Associate(
            string objectType,
            long objectId,
            string toObjectType,
            long toObjectId,
            string associationType)
        {
            var path =
                $"/crm/v3/objects/{objectType}/{objectId}/associations/{toObjectType}/{toObjectId}/{associationType}";
            await client.Execute(path, HttpMethod.Put);
        }

        /// <inheritdoc cref="Associate(string, long, string, long, string)" />
        public async Task Associate<TToObject>(
            string objectType,
            long objectId,
            long toObjectId,
            string associationType)
        {
            await Associate(
                objectType,
                objectId,
                AssociationIdAttribute.GetId<TToObject>(),
                toObjectId,
                associationType);
        }

        /// <summary>
        /// Removes an association between a custom object and another object.
        /// </summary>
        /// <param name="objectType">
        /// The type of the custom object
        /// </param>
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
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task RemoveAssociation(
            string objectType,
            long objectId,
            string toObjectType,
            long toObjectId,
            string associationType)
        {
            var path =
                $"/crm/v3/objects/{objectType}/{objectId}/associations/{toObjectType}/{toObjectId}/{associationType}";
            await client.Execute(path, HttpMethod.Delete);
        }

        /// <inheritdoc cref="RemoveAssociation(string, long, string, long, string)" />
        public async Task RemoveAssociation<TToObjectType>(
            string objectType,
            long objectId,
            long toObjectId,
            string associationType)
            where TToObjectType : HubSpotObject
        {
            await RemoveAssociation(
                objectType,
                objectId,
                AssociationIdAttribute.GetId<TToObjectType>(),
                toObjectId,
                associationType);
        }

        /// <summary>
        /// Creates a custom object of the specified type
        /// </summary>
        /// <typeparam name="T">
        /// The custom object's type
        /// </typeparam>
        /// <param name="objectType">
        /// The object's Type id.
        /// </param>
        /// <param name="obj">
        /// The object to create.
        /// </param>
        /// <returns>
        /// The created <typeparamref name="T"/>
        /// </returns>
        public async Task<T> Create<T>(string objectType, T obj)
            where T : HubSpotObject, new()
        {
            var path = "/crm/v3/objects/" + objectType;
            var pack = new PropertyBag<T>(obj);
            return (await client.Execute<PropertyBag<T>>(path, HttpMethod.Post, pack)).GetProperties();
        }

        /// <summary>
        /// Read a custom object.
        /// </summary>
        /// <param name="objectType">
        /// The object type id.
        /// </param>
        /// <param name="objectId">
        /// The id of the object.
        /// </param>
        /// <typeparam name="T">
        /// The object type to read.
        /// </typeparam>
        /// <returns>
        /// The retrieved <typeparamref name="T"/>
        /// </returns>
        public async Task<T> Read<T>(string objectType, long objectId)
            where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}";
            return (await client.Execute<PropertyBag<T>>(path)).GetProperties();
        }

        /// <summary>
        /// List all custom objects of a type.
        /// </summary>
        /// <param name="objectType">
        /// The object type to list.
        /// </param>
        /// <param name="limit">
        /// How many objects to read.
        /// </param>
        /// <param name="after">
        /// The offset to begin reading at.
        /// </param>
        /// <param name="properties">
        /// The properties to return.
        /// </param>
        /// <typeparam name="T">
        /// The type of the object to read.
        /// </typeparam>
        /// <returns>
        /// A list of the retrieved objects.
        /// </returns>
        public async Task<ListResult<PropertyBag<T>>> List<T>(
            string objectType,
            int limit = 100,
            string? after = null,
            IList<string>? properties = null)
            where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}";
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

            return await client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        /// <summary>
        /// Update a custom object.
        /// </summary>
        /// <param name="objectId">
        /// The object type id.
        /// </param>
        /// <param name="obj">
        /// The object to update.
        /// </param>
        /// <typeparam name="T">
        /// The type of the object to update
        /// </typeparam>
        /// <returns>
        /// The updated object.
        /// </returns>
        public async Task<T> Update<T>(string objectId, T obj)
            where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectId}/{obj.Id}";
            var pack = new PropertyBag<T>(obj);
            return (await client.Execute<PropertyBag<T>>(path, HttpMethod.Patch, pack)).GetProperties();
        }

        /// <summary>
        /// Archives a custom object, it will be deleted after 90 days.
        /// </summary>
        /// <param name="objectType">
        /// The object type id.
        /// </param>
        /// <param name="objectId">
        /// The id of the object to archive.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task Archive(string objectType, long objectId)
        {
            var path = $"/crm/v3/objects/{objectType}/{objectId}";
            await client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// Creates a batch of custom objects.
        /// </summary>
        /// <param name="objectType">
        /// The object type id.
        /// </param>
        /// <param name="objects">
        /// The objects to create.
        /// </param>
        /// <typeparam name="T">
        /// The type of the objects.
        /// </typeparam>
        /// <returns>
        /// A list of the created objects.
        /// </returns>
        public async Task<BatchResult<PropertyBag<T>>> CreateBatch<T>(
            string objectType,
            ListInputs<PropertyBag<T>> objects)
            where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}/batch/create";
            return await client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, objects);
        }

        /// <inheritdoc cref="CreateBatch{T}(string, ListInputs{PropertyBag{T}})" />
        public async Task<BatchResult<PropertyBag<T>>> CreateBatch<T>(string objectType, IList<T> objects)
            where T : HubSpotObject, new()
        {
            return await CreateBatch(objectType, new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(objects)));
        }

        /// <summary>
        /// Reads a set of custom objects using a set of unique property values.
        /// </summary>
        /// <param name="objectType">
        /// The object type id.
        /// </param>
        /// <param name="options">
        /// The selection parameters used to identify the objects.
        /// </param>
        /// <typeparam name="T">
        /// The type of the custom object.
        /// </typeparam>
        /// <returns>
        /// A list of the retrieved objects.
        /// </returns>
        public async Task<BatchResult<PropertyBag<T>>> ReadByProperties<T>(
            string objectType,
            SelectByPropertiesOptions options)
            where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}/batch/read";
            return await client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, options);
        }

        /// <summary>
        /// Updates a batch of custom objects
        /// </summary>
        /// <param name="objectType">
        /// The object type id.
        /// </param>
        /// <param name="objects">
        /// The objects to update.
        /// </param>
        /// <typeparam name="T">
        /// The type of the objects.
        /// </typeparam>
        /// <returns>
        /// A list of the updated objects.
        /// </returns>
        public async Task<BatchResult<PropertyBag<T>>> UpdateBatch<T>(
            string objectType,
            ListInputs<PropertyBag<T>> objects)
            where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}/batch/update";
            return await client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, objects);
        }

        /// <inheritdoc cref="UpdateBatch{T}(string, ListInputs{PropertyBag{T}})" />
        public async Task<BatchResult<PropertyBag<T>>> UpdateBatch<T>(string objectType, IList<T> objects)
            where T : HubSpotObject, new()
        {
            return await UpdateBatch(objectType, new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(objects)));
        }

        /// <summary>
        /// Searches for custom objects.
        /// </summary>
        /// <param name="objectType">
        /// The object type id.
        /// </param>
        /// <param name="options">
        /// The search options.
        /// </param>
        /// <typeparam name="T">
        /// The type of the custom object.
        /// </typeparam>
        /// <returns>
        /// A list of search results.
        /// </returns>
        public async Task<SearchResults<T>> Search<T>(string objectType, SearchOptions options)
            where T : HubSpotObject, new()
        {
            var path = $"/crm/v3/objects/{objectType}/search";
            var requestOptions = new RequestOptions(path, HttpMethod.Post, options, RateLimitOptions.RetrySearch);
            return await client.Execute<SearchResults<T>>(requestOptions);
        }
    }
}