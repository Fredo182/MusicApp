using System;
using MusicApp.API.Contracts.V1.Requests.Queries;

namespace MusicApp.API.Services.Interfaces
{
    public interface IUriService
    {
        Uri GetArtistUri(string artistId);
        Uri GetAllArtistsUri(PaginationQuery pagination = null);

        // Add all endpoints below
    }
}
