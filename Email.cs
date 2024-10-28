using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Newtonsoft.Json;
using Microsoft.Graph.Users.Item.SendMail;

namespace appsvc_function_dev_cm_email_dotnet001
{
    public class Email
    {
        private readonly ILogger<Email> _logger;

        public Email(ILogger<Email> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Email))]
        public async Task RunAsync([QueueTrigger("email", Connection = "AzureWebJobsStorage")] QueueMessage message)
        {
            _logger.LogInformation($"Email queue executed at {DateTime.Now}");

            try
            {
                var scopes = new[] { "user.read mail.send" };
                ROPCConfidentialTokenCredential auth = new ROPCConfidentialTokenCredential(_logger);
                var graphClient = new GraphServiceClient(auth, scopes);

                var queueMessage = JsonConvert.DeserializeObject<CMQueueMessage>(message.Body.ToString());

                await SendEmail(graphClient, queueMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error sending email: {ex.Message} - {ex.StackTrace}");
            }
        }
        
        private async Task SendEmail(GraphServiceClient graphClient, CMQueueMessage message)
        {
            try
            {
                SubjectAndBody subAndBody;

                switch (message.EmailType)
                {
                    case EmailType.Create:
                        subAndBody = Templates.CreateOpportunity(message.JobOpportunity);
                        break;
                    case EmailType.Delete:
                        subAndBody = Templates.DeleteOpportunity(message.JobOpportunity);
                        break;
                    default:
                        throw new ArgumentException($"Invalid EmailType. Must be one of \"{string.Join("\" OR \"", Enum.GetValues(typeof(EmailType)))}\"");
                }

                var msg = new Message
                {
                    Subject = subAndBody.Subject,
                    Body = new ItemBody
                    {
                        ContentType = BodyType.Html,
                        Content = subAndBody.Body
                    },
                    ToRecipients = new List<Recipient>()
                    {
                        new Recipient
                        {
                            EmailAddress = new EmailAddress
                            {
                                Address = message.EmailRecipient
                            }
                        }
                    }
                };

                var requestBody = new SendMailPostRequestBody
                {
                    Message = msg,
                    SaveToSentItems = false
                };

                await graphClient.Users[Globals.delegateEmail].SendMail.PostAsync(requestBody);

                _logger.LogInformation($"Email sent to {message.EmailRecipient}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong during SendEmail: {ex.Message} - {ex.StackTrace}");
            }
        }
    }
}
