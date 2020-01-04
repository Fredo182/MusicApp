using System;
namespace MusicApp.API.Contracts.V1
{
    public static class ErrorMessages
    {
        public static class Artist
        {
            public const string FailedCreate =      "Failed to create artist.";
            public const string FailedRead =        "Failed to get artist.";
            public const string FailedUpdate =      "Failed to update artist.";
            public const string FailedDelete =      "Failed to delete artist.";

            public const string FailedCreateBulk =  "Failed to create artists.";
            public const string FailedUpdateBulk =  "Failed to update artists.";
            public const string FailedDeleteBulk =  "Failed to delete artusts.";

            public const string DoesNotExist =      "Artist does not exist.";
            public const string NameExists =        "Artist name already exists.";
            public const string MismatchId =        "ArtistId is incorrect.";

            public const string DoesNotExistBulk =  "Artist(s) do not exist.";
            public const string NameExistsBulk =    "Artist(s) name(s) already exist.";

            public const string ConcurrencyIssue = "The Artist you attempted to edit has been modified by another user.";
            public const string ConcurrencyIssueBulk = "Artist(s) you attempted to edit have been modified by another user.";
        }

        public static class Account
        {
            public const string FailedRegister =        "Failed to register user.";
            public const string FailedLogin =           "Failed to login user.";
            public const string FailedConfirmEmail =    "Failed to confirm user email.";
            public const string FailedPasswordReset =   "Failed to reset password.";

            public const string UserNotFound =              "The user does not exist.";
            public const string EmailNotConfirmed =         "The email associated with this account has not been confirmed.";
            public const string FailedConfirmEmailSent =    "Email failed to send for confirmation.";
            public const string FailedPasswordResetSent =   "Email failed to send for password reset.";
        }

        public static class Identity
        {
            public const string DefaultError =                      "An unknown failure has occured.";
            public const string ConcurrencyFailure =                "The model you attempted to edit has been modified by another user.";
            public const string PasswordMismatch =                  "The passwords do not match.";
            public const string InvalidToken =                      "The token is no longer valid.";
            public const string RecoveryCodeRedemptionFailed =      "Recovery code was not redeemed.";
            public const string LoginAlreadyAssociated =            "The external login has already been associated with the account.";
            public const string InvalidUserName =                   "The username is invalid.";
            public const string InvalidEmail =                      "The email is invalid";
            public const string DuplicateUserName =                 "User name already exists.";
            public const string DuplicateEmail =                    "Email is already associated to an account.";
            public const string InvalidRoleName =                   "The role name is invalid.";
            public const string DuplicateRoleName =                 "Role name already exists.";
            public const string UserAlreadyHasPassword =            "The user already has a password.";
            public const string UserLockoutNotEnabled =             "User lockout is not enabled.";
            public const string UserAlreadyInRole =                 "User already has role.";
            public const string UserNotInRole =                     "User is not in role.";
            public const string PasswordTooShort =                  "The password length is too short.";
            public const string PasswordRequiresUniqueChars =       "The password does not meet the minimum amount of unique characters.";
            public const string PasswordRequiresNonAlphanumeric =   "The password requires non alphanumeric characters.";
            public const string PasswordRequiresDigit =             "The password requires at least one digit.";
            public const string PasswordRequiresLower =             "The password requires at least one lower case character.";
            public const string PasswordRequiresUpper =             "The password requires at least one upper case character.";

        }
    }
}
