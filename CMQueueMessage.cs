using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace appsvc_function_dev_cm_email_dotnet001
{
    internal class CMQueueMessage
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public required EmailType EmailType { get; set; }
        public required string EmailRecipient { get; set; }
        public required JobOpportunity JobOpportunity { get; set; }
    }

    public enum EmailType
    {
        Create,
        Delete
    }
}
