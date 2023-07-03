namespace HubSpot_Sharp.Webhook
{
    public class ValidationInformationV3
    {
        public string Signature { get; set; }

        public DateTime TimeStamp { get; set; }

        public string Method { get; set; }

        public string Uri { get; set; }

        public string Body { get; set; }
    }
}
