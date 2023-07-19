namespace HubSpot_Sharp.CRM.Property
{
    using HubSpot_Sharp.Intermediates;

    public class PropertyApi
    {
        private readonly HubSpotClient client;
        public PropertyApi(HubSpotClient client)
        {
            this.client = client;
        }

        public async Task<ListResult<PropertyInformation>> GetAll(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return await client.Execute<ListResult<PropertyInformation>>(path);
        }

        public async Task<PropertyInformation> Create(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return await client.Execute<PropertyInformation>(path, HttpMethod.Post, property);
        }

        public async Task<PropertyInformation> Get(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            return await client.Execute<PropertyInformation>(path);
        }

        public async Task<PropertyInformation> Update(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}/{property.Name}";
            return await client.Execute<PropertyInformation>(path, HttpMethod.Patch, property);
        }

        public async Task Archive(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            await client.Execute(path, HttpMethod.Delete);
        }

        public async Task ArchiveBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/archive";
            await client.Execute(path, HttpMethod.Post, inputs);
        }
        public async Task ArchiveBatch(string objectType, IList<string> inputs)
        {
            await ArchiveBatch(objectType, new ListInputs<NameInput>(inputs.Select(i => new NameInput(i)).ToList()));
        }

        public async Task<BatchResult<PropertyInformation>> CreateBatch(string objectType, ListInputs<ObjectProperty> properties)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/create";
            return await client.Execute<BatchResult<PropertyInformation>>(path, HttpMethod.Post, properties);
        }

        public async Task<BatchResult<PropertyInformation>> ReadBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/read";
            return await client.Execute<BatchResult<PropertyInformation>>(path, HttpMethod.Post, inputs);
        }

        public async Task<ListResult<PropertyGroup>> ReadGroups(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return await client.Execute<ListResult<PropertyGroup>>(path);
        }

        public async Task<PropertyGroup> CreateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return await client.Execute<PropertyGroup>(path, HttpMethod.Post, group);
        }

        public async Task<PropertyGroup> ReadGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            return await client.Execute<PropertyGroup>(path);
        }

        public async Task<PropertyGroup> UpdateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{group.Name}";
            return await client.Execute<PropertyGroup>(path, HttpMethod.Patch, group);
        }

        public async Task DeleteGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            await client.Execute(path, HttpMethod.Delete);
        }
    }
}
