using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class EmailService : IEmailService
    {
        private ILogger<EmailService> _logger;

        public EmailService(ILogger<EmailService> logger)
        {
            _logger = logger;
        }

        public bool SendConfirmationEmail(string email, string token)
        {
            
            return true;
        }

        public bool SendConfirmEmail(string email, string url)
        {
            _logger.LogWarning("Confirm Email: " + email + Environment.NewLine + "Url: " + url);
            return true;
        }

        public bool SendPasswordReset(string email, string url)
        {
            _logger.LogWarning("Password Reset: " + email + Environment.NewLine + "Url: " + url);
            return true;
        }
    }
}
