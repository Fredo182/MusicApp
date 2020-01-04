using System;
using System.Threading.Tasks;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IEmailService
    {
        bool SendConfirmEmail(string email, string url);
        bool SendPasswordReset(string email, string url);
    }
}
