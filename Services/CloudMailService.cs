namespace CityInfoAPI.Services
{
    public class CloudMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public CloudMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }
        public void Send(string subject, string message)
        {
            // send mail - output to console window
            Console.WriteLine($"Mail from {_mailTo} to mail to {_mailTo}, " +
                $"With {nameof(CloudMailService)}.");
            Console.WriteLine($"Subject; {subject}");
            Console.WriteLine($"Message; {message}");
        }
    }
}
