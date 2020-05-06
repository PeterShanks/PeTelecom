namespace PeTelecom.BuildingBlocks.Infrastructure.Emails
{
    public class EmailConfiguration
    {
        public string FromEmail { get; }

        public EmailConfiguration(string fromEmail)
        {
            FromEmail = fromEmail;
        }
    }
}
