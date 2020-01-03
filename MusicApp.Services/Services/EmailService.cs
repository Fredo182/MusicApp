using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class EmailService : IEmailService
    {
        private ILogger _logger;

        public EmailService(ILogger logger)
        {
            _logger = logger;
        }

        public bool SendConfirmationEmail(string email, string token)
        {
            _logger.LogInformation("Confirm Email: " + email + Environment.NewLine + "Token: " + token);
            return true;
        }
    }
}
