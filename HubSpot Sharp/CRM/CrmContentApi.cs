// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CrmObjectApi.cs" company="">
//   
// </copyright>
// <summary>
//   The base class for crm api endpoint collections.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;

using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;
using HubSpot_Sharp.Search;

namespace HubSpot_Sharp.CRM
{
    /// <summary>
    /// The base class for crm api endpoint collections.
    /// </summary>
    /// <typeparam name="THubType">
    /// The object type the api works on.
    /// </typeparam>
    public abstract class CrmContentApi<THubType>
        where THubType : HubSpotObject
    {
        /// <summary>
        /// The HubSpot client to make requests with.
        /// </summary>
        protected readonly HubSpotClient Client;

        /// <summary>
        /// The url path extension used to access the object in the api.
        /// </summary>
        private readonly string pathSegment;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrmContentApi{THubType}"/> class with the specified type.
        /// </summary>
        /// <param name="client">
        /// The HubSpot client to make requests with.
        /// </param>
        public CrmContentApi(HubSpotClient client)
        {
            this.Client = client;
            pathSegment = ApiPathNameAttribute.GetSegment<THubType>()
                          ?? throw new Exception("Attempt to create a object api without an api path attribute.");
        }

        /// <summary>
        /// Creates a <typeparamref name="T"/> of the specified type
        /// </summary>
        /// <typeparam name="T">
        /// The <typeparamref name="THubType"/>'s specific type
        /// </typeparam>
        /// <param name="options">
        /// The object to create.
        /// </param>
        /// <returns>
        /// The created <typeparamref name="T"/>
        /// </returns>
        public async Task<T> Create<T>(AssociatedProperties<T> options)
            where T : THubType
        {
            var path = $"/crm/v3/objects/{pathSegment}";
            return (await Client.Execute<PropertyBag<T>>(path, HttpMethod.Post, options)).GetProperties();
        }

        /// <summary>
        /// Read a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="objectId">
        /// The id of the object.
        /// </param>
        /// <typeparam name="T">
        /// The object type to read.
        /// </typeparam>
        /// <returns>
        /// The retrieved <typeparamref name="T"/>
        /// </returns>
        public async Task<T> Read<T>(long objectId)
            where T : THubType
        {
            var path = $"/crm/v3/objects/{pathSegment}/{objectId}";
            return (await Client.Execute<PropertyBag<T>>(path)).GetProperties();
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
        /// <typeparam name="T">
        /// The type of the object to read.
        /// </typeparam>
        /// <returns>
        /// A list of the retrieved objects.
        /// </returns>
        public async Task<ListResult<PropertyBag<T>>> List<T>(
            int limit = 100,
            string? after = null,
            IList<string>? properties = null)
            where T : THubType
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

            return await Client.Execute<ListResult<PropertyBag<T>>>(options);
        }

        /// <summary>
        /// Update a <typeparamref name="T"/>.
        /// </summary>
        /// <param name="obj">
        /// The object to update.
        /// </param>
        /// <typeparam name="T">
        /// The type of the <typeparamref name="THubType"/> to update
        /// </typeparam>
        /// <returns>
        /// The updated object.
        /// </returns>
        public async Task<T> Update<T>(T obj)
            where T : THubType
        {
            var path = $"/crm/v3/objects/{pathSegment}/{obj.Id}";
            var pack = new PropertyBag<T>(obj);
            return (await Client.Execute<PropertyBag<T>>(path, HttpMethod.Patch, pack)).GetProperties();
        }

        /// <summary>
        /// Archives a <typeparamref name="THubType"/> object, it will be deleted after 90 days.
        /// </summary>
        /// <param name="objectId">
        /// The id of the object to archive.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that completes when the object is archived.
        /// </returns>
        public async Task Archive(long objectId)
        {
            var path = $"/crm/v3/objects/{pathSegment}/{objectId}";
            await Client.Execute(path, HttpMethod.Delete);
        }

        /// <summary>
        /// Archives a batch of <typeparamref name="THubType"/> objects, they will be deleted in 90 days.
        /// </summary>
        /// <param name="inputs">
        /// The id's of the objects to archive.
        /// </param>
        /// <returns>
        /// A <see cref="Task"/> that completes when the objects are archived.
        /// </returns>
        public async Task ArchiveBatch(ListInputs<IdObject> inputs)
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/archive";
            await Client.Execute(path, HttpMethod.Post, inputs);
        }

        /// <summary>
        /// Creates a batch of <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects">
        /// The objects to create.
        /// </param>
        /// <typeparam name="T">
        /// The type of the objects.
        /// </typeparam>
        /// <returns>
        /// A list of the created objects.
        /// </returns>
        public async Task<BatchResult<PropertyBag<T>>> CreateBatch<T>(ListInputs<AssociatedProperties<T>> objects)
            where T : THubType
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/create";
            return await Client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, objects);
        }

        /// <summary>
        /// Reads a set of <typeparamref name="T"/> objects using a set of unique property values.
        /// </summary>
        /// <param name="options">
        /// The selection parameters used to identify the objects.
        /// </param>
        /// <typeparam name="T">
        /// The type of the <typeparamref name="THubType"/>.
        /// </typeparam>
        /// <returns>
        /// A list of the retrieved objects.
        /// </returns>
        public async Task<BatchResult<PropertyBag<T>>> ReadByProperties<T>(SelectByPropertiesOptions options)
            where T : THubType
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/read";
            return await Client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, options);
        }

        /// <summary>
        /// Updates a batch of <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="objects">
        /// The objects to update.
        /// </param>
        /// <typeparam name="T">
        /// The type of the objects.
        /// </typeparam>
        /// <returns>
        /// A list of the updated objects.
        /// </returns>
        public async Task<BatchResult<PropertyBag<T>>> UpdateBatch<T>(ListInputs<PropertyBag<T>> objects)
            where T : THubType
        {
            var path = $"/crm/v3/objects/{pathSegment}/batch/update";
            return await Client.Execute<BatchResult<PropertyBag<T>>>(path, HttpMethod.Post, objects);
        }

        /// <summary>
        /// Searches for <typeparamref name="T"/> objects.
        /// </summary>
        /// <param name="options">
        /// The search options.
        /// </param>
        /// <typeparam name="T">
        /// The type of the <typeparamref name="THubType"/>.
        /// </typeparam>
        /// <returns>
        /// A list of search results.
        /// </returns>
        public async Task<SearchResults<T>> Search<T>(SearchOptions options)
            where T : THubType
        {
            var path = $"/crm/v3/objects/{pathSegment}/search";
            var requestOptions = new RequestOptions(
                path,
                HttpMethod.Post,
                options,
                rateLimit: RateLimitOptions.RetrySearch);
            return await Client.Execute<SearchResults<T>>(requestOptions);
        }
    }

    /// <summary>
    /// Contains overloads for the crm content api.
    /// </summary>
    public static class CrmContentApiExtensions
    {
        /// <inheritdoc cref="CrmContentApi{THubType}.Create{T}(AssociatedProperties{T})"/>
        public static async Task<T> Create<THubType, T>(this CrmContentApi<THubType> api, T obj) where THubType : HubSpotObject where T : THubType
        {
            return await api.Create(new AssociatedProperties<T>(obj));
        }

        /// <inheritdoc cref="CrmContentApi{THubType}.CreateBatch{T}(ListInputs{AssociatedProperties{T}})"/>
        public static async Task<BatchResult<PropertyBag<T>>> CreateBatch<THubType, T>(this CrmContentApi<THubType> api, IList<T> objects) where THubType : HubSpotObject where T : THubType
        {
            var body = new ListInputs<AssociatedProperties<T>>(objects.Select(p => new AssociatedProperties<T>(p)).ToList());
            return await api.CreateBatch(body);
        }

        /// <inheritdoc cref="CrmContentApi{THubType}.UpdateBatch{T}(ListInputs{PropertyBag{T}})" />
        public static async Task<BatchResult<PropertyBag<T>>> UpdateBatch<THubType, T>(this CrmContentApi<THubType> api, IList<T> objects) where THubType : HubSpotObject where T : THubType
        {
            return await api.UpdateBatch(new ListInputs<PropertyBag<T>>(PropertyBag<T>.PackMany(objects)));
        }
        
        /// <inheritdoc cref="CrmContentApi{THubType}.ArchiveBatch(ListInputs{IdObject})" />
        public static async Task ArchiveBatch<THubType, T>(this CrmContentApi<THubType> api, IList<T> objects) where THubType : HubSpotObject where T : THubType
        {
            await api.ArchiveBatch(new ListInputs<IdObject>(IdObject.FromEnumerable(objects)));
        }
    }
}