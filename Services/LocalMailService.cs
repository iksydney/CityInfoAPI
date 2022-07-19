﻿namespace CityInfoAPI.Services
{
    public class LocalMailService : IMailService
    {
        private readonly string _mailTo = string.Empty;
        private readonly string _mailFrom = string.Empty;

        public LocalMailService(IConfiguration configuration)
        {
            _mailTo = configuration["mailSettings:mailToAddress"];
            _mailFrom = configuration["mailSettings:mailFromAddress"];
        }
        public void Send(string subject, string message)
        {
            // send mail - output to console window
            Console.WriteLine($"Mail from {_mailTo} to mail to {_mailTo}, " +
                $"With {nameof(LocalMailService)}.");
            Console.WriteLine($"Subject; {subject}");
            Console.WriteLine($"Message; {message}");
        }
    }
}
