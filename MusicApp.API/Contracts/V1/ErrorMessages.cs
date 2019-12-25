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
    }
}
