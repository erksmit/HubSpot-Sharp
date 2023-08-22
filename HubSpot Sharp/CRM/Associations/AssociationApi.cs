// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssociationApi.cs" company="">
//   
// </copyright>
// <summary>
//   The association api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using HubSpot_Sharp.CRM.Associations.Schema;
using HubSpot_Sharp.Intermediates;
using HubSpot_Sharp.Options;

namespace HubSpot_Sharp.CRM.Associations
{
    /// <summary>
    /// The associations api.
    /// </summary>
    public class AssociationApi
    {
        /// <summary>
        /// The HubSpot client to make requests with.
        /// </summary>
        private readonly HubSpotClient client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AssociationApi"/> class.
        /// </summary>
        /// <param name="client">
        /// The client.
        /// </param>
        public AssociationApi(HubSpotClient client)
        {
            this.client = client;
            Schema = new AssociationSchemaApi(client);
        }

        /// <summary>
        /// Gets the association schema api
        /// </summary>
        public AssociationSchemaApi Schema { get; }

        public async Task<ListResult<AssociationsListEntry>> List(
            string objectType,
            int objectId,
            string toObjectType,
            string? after = null,
            int limit = 500)
        {
            string path = $"/crm/v4/objects/{objectType}/{objectId}/associations/{toObjectType}";
            var options = new RequestOptions(path);

            options.AddParam("limit", limit);
            if (after != null)
            {
                options.AddParam("after", after);
            }

            return await client.Execute<ListResult<AssociationsListEntry>>(options);
        }

        public async Task<CreatedAssociation> Create(
            string objectType,
            int objectId,
            string toObjectType,
            int toObjectId,
            IList<AssociationType> types)
        {
            string path = $"/crm/v4/objects/{objectType}/{objectId}/associations/{toObjectType}/{toObjectId}";
            return await client.Execute<CreatedAssociation>(path, HttpMethod.Put, types);
        }

        public async Task Delete(string objectType, int objectId, string toObjectType, int toObjectId)
        {
            string path = $"/crm/v4/objects/{objectType}/{objectId}/associations/{toObjectType}/{toObjectId}";
            await client.Execute(path, HttpMethod.Delete);
        }

        public async Task<BatchResult<CreatedDefaultAssociation>> CreateDefault(
            string fromObjectType,
            int fromObjectId,
            string toObjectType,
            int toObjectId)
        {
            string path =
                $"/crm/v4/objects/{fromObjectType}/{fromObjectId}/associations/default/{toObjectType}/{toObjectId}";
            return await client.Execute<BatchResult<CreatedDefaultAssociation>>(path, HttpMethod.Put);
        }

        public async Task<BatchResult<AssociationReadResult>> ReadBatch(
            string fromObjectType,
            string toObjectType,
            ListInputs<AssociationReadInput> inputs)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/batch/read";
            return await client.Execute<BatchResult<AssociationReadResult>>(path, HttpMethod.Post, inputs);
        }

        public async Task DeleteSpecificBatch(
            string fromObjectType, 
            string toObjectType, 
            ListInputs<AssociationLabelInput> inputs)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/batch/labels/archive";
            await client.Execute(path, HttpMethod.Post, inputs);
        }

        public async Task<BatchResult<CreatedAssociation>> CreateBatch(
            string fromObjectType,
            string toObjectType,
            ListInputs<AssociationLabelInput> inputs)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/batch/create";
            return await client.Execute<BatchResult<CreatedAssociation>>(path, HttpMethod.Post, inputs);
        }

        public async Task<BatchResult<CreatedDefaultAssociation>> CreateDefaultBatch(
            string fromObjectType,
            string toObjectType,
            ListInputs<AssociationIdInput> inputs)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/batch/associate/default";
            return await client.Execute<BatchResult<CreatedDefaultAssociation>>(path, HttpMethod.Post, inputs);
        }

        public async Task DeleteBatch(string fromObjectType, string toObjectType, AssociationIdInput inputs)
        {
            string path = $"/crm/v4/associations/{fromObjectType}/{toObjectType}/batch/archive";
            await client.Execute(path, HttpMethod.Post, inputs);
        }
    }
}