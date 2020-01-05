using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using MusicApp.API.Contracts.V1;
using MusicApp.Services.Services.Responses;

namespace MusicApp.API.Helpers
{
    public static class AccountErrorsToResponse
    {
        // This parses the identity errors with error messages in contracts for v1
        public static IEnumerable<string> Parse(AccountServiceResponse response)
        {
            List<string> result = new List<string>();
            if (response.EmailNotConfirmed)
                result.Add(ErrorMessages.Account.EmailNotConfirmed);
            else if (response.SendConfirmEmailFailed)
                result.Add(ErrorMessages.Account.FailedConfirmEmailSent);
            else if (response.SendResetPasswordFailed)
                result.Add(ErrorMessages.Account.FailedPasswordResetSent);
            else if (response.UserNotFound)
                result.Add(ErrorMessages.Account.UserNotFound);
            else if (response.Errors.Any())
                result.AddRange(Parse(response.Errors));
            return result;
        }

        // This parses the identity errors with error messages in contracts for v1
        public static IEnumerable<string> Parse(IEnumerable<IdentityError> errors)
        {
            List<string> result = new List<string>();
            foreach (var error in errors)
            {
                switch (error.Code)
                {
                    case nameof(IdentityErrorDescriber.ConcurrencyFailure):
                        result.Add(ErrorMessages.Identity.ConcurrencyFailure);
                        break;
                    case nameof(IdentityErrorDescriber.PasswordMismatch):
                        result.Add(ErrorMessages.Identity.PasswordMismatch);
                        break;
                    case nameof(IdentityErrorDescriber.InvalidToken):
                        result.Add(ErrorMessages.Identity.InvalidToken);
                        break;
                    case nameof(IdentityErrorDescriber.RecoveryCodeRedemptionFailed):
                        result.Add(ErrorMessages.Identity.RecoveryCodeRedemptionFailed);
                        break;
                    case nameof(IdentityErrorDescriber.LoginAlreadyAssociated):
                        result.Add(ErrorMessages.Identity.LoginAlreadyAssociated);
                        break;
                    case nameof(IdentityErrorDescriber.InvalidUserName):
                        result.Add(ErrorMessages.Identity.InvalidUserName);
                        break;
                    case nameof(IdentityErrorDescriber.InvalidEmail):
                        result.Add(ErrorMessages.Identity.InvalidEmail);
                        break;
                    case nameof(IdentityErrorDescriber.DuplicateUserName):
                        result.Add(ErrorMessages.Identity.DuplicateUserName);
                        break;
                    case nameof(IdentityErrorDescriber.DuplicateEmail):
                        result.Add(ErrorMessages.Identity.DuplicateEmail);
                        break;
                    case nameof(IdentityErrorDescriber.InvalidRoleName):
                        result.Add(ErrorMessages.Identity.InvalidRoleName);
                        break;
                    case nameof(IdentityErrorDescriber.DuplicateRoleName):
                        result.Add(ErrorMessages.Identity.DuplicateRoleName);
                        break;
                    case nameof(IdentityErrorDescriber.UserAlreadyHasPassword):
                        result.Add(ErrorMessages.Identity.UserAlreadyHasPassword);
                        break;
                    case nameof(IdentityErrorDescriber.UserLockoutNotEnabled):
                        result.Add(ErrorMessages.Identity.UserLockoutNotEnabled);
                        break;
                    case nameof(IdentityErrorDescriber.UserAlreadyInRole):
                        result.Add(ErrorMessages.Identity.UserAlreadyInRole);
                        break;
                    case nameof(IdentityErrorDescriber.UserNotInRole):
                        result.Add(ErrorMessages.Identity.UserNotInRole);
                        break;
                    case nameof(IdentityErrorDescriber.PasswordTooShort):
                        result.Add(ErrorMessages.Identity.PasswordTooShort);
                        break;
                    case nameof(IdentityErrorDescriber.PasswordRequiresUniqueChars):
                        result.Add(ErrorMessages.Identity.PasswordRequiresUniqueChars);
                        break;
                    case nameof(IdentityErrorDescriber.PasswordRequiresNonAlphanumeric):
                        result.Add(ErrorMessages.Identity.PasswordRequiresNonAlphanumeric);
                        break;
                    case nameof(IdentityErrorDescriber.PasswordRequiresDigit):
                        result.Add(ErrorMessages.Identity.PasswordRequiresDigit);
                        break;
                    case nameof(IdentityErrorDescriber.PasswordRequiresLower):
                        result.Add(ErrorMessages.Identity.PasswordRequiresLower);
                        break;
                    case nameof(IdentityErrorDescriber.PasswordRequiresUpper):
                        result.Add(ErrorMessages.Identity.PasswordRequiresUpper);
                        break;
                    default:
                        result.Add(ErrorMessages.Identity.DefaultError);
                        break;
                }
            }

            return result;
        }
    }
}



