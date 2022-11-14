using System.Runtime.Serialization;

namespace HubSpot_Sharp.Intermediates
{
    [DataContract]
    public class NameInput
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        public NameInput()
        {
        }

        public NameInput(string name)
        {
            Name = name;
        }
    }
}
