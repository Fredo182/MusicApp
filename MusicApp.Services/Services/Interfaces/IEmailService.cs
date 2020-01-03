using System;
using System.Threading.Tasks;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IEmailService
    {
        bool SendConfirmationEmail(string email, string token);
    }
}
