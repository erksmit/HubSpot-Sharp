namespace HubSpot_Sharp.CRM.Property
{
    using HubSpot_Sharp.CRM.Custom;
    using HubSpot_Sharp.Intermediates;

    public class PropertyApi
    {
        private readonly HubSpotClient client;
        public PropertyApi(HubSpotClient client)
        {
            this.client = client;
        }

        public ListResult<PropertyInformation> GetAll(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return client.Execute<ListResult<PropertyInformation>>(path);
        }

        public PropertyInformation Create(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}";
            return client.Execute<PropertyInformation>(path, HttpMethod.Post, property);
        }

        public PropertyInformation Get(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            return client.Execute<PropertyInformation>(path);
        }

        public PropertyInformation Update(string objectType, ObjectProperty property)
        {
            var path = $"/crm/v3/properties/{objectType}/{property.Name}";
            return client.Execute<PropertyInformation>(path, HttpMethod.Patch, property);
        }

        public void Archive(string objectType, string propertyName)
        {
            var path = $"/crm/v3/properties/{objectType}/{propertyName}";
            client.Execute(path, HttpMethod.Delete);
        }

        public void ArchiveBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/archive";
            client.Execute(path, HttpMethod.Post, inputs);
        }
        public void ArchiveBatch(string objectType, IList<string> inputs)
        {
            ArchiveBatch(objectType, new ListInputs<NameInput>(inputs.Select(i => new NameInput(i)).ToList()));
        }

        public BatchResult<PropertyInformation> CreateBatch(string objectType, ListInputs<ObjectProperty> properties)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/create";
            return client.Execute<BatchResult<PropertyInformation>>(path, HttpMethod.Post, properties);
        }

        public BatchResult<PropertyInformation> ReadBatch(string objectType, ListInputs<NameInput> inputs)
        {
            var path = $"/crm/v3/properties/{objectType}/batch/read";
            return client.Execute<BatchResult<PropertyInformation>>(path, HttpMethod.Post, inputs);
        }

        public ListResult<PropertyGroup> ReadGroups(string objectType)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return client.Execute<ListResult<PropertyGroup>>(path);
        }

        public PropertyGroup CreateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups";
            return client.Execute<PropertyGroup>(path, HttpMethod.Post, group);
        }

        public PropertyGroup ReadGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            return client.Execute<PropertyGroup>(path);
        }

        public PropertyGroup UpdateGroup(string objectType, PropertyGroup group)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{group.Name}";
            return client.Execute<PropertyGroup>(path, HttpMethod.Patch, group);
        }

        public void DeleteGroup(string objectType, string groupName)
        {
            var path = $"/crm/v3/properties/{objectType}/groups/{groupName}";
            client.Execute(path, HttpMethod.Delete);
        }
    }
}
