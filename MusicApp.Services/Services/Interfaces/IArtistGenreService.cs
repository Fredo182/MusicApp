using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IArtistGenreService
    {
        // CREATE
        Task<ArtistGenreModel> CreateArtistGenre(ArtistGenreModel artistGenre);
        Task<IEnumerable<ArtistGenreModel>> CreateArtistGenres(IEnumerable<ArtistGenreModel> artistGenres);

        // READ
        Task<ArtistGenreModel> GetArtistGenreById(int id);
        Task<ArtistGenreModel> GetArtistGenre(ArtistGenreModel artistGenre);
        Task<IEnumerable<ArtistGenreModel>> GetAllAlbums();

        // UPDATE
        Task<ArtistGenreModel> UpdateArtistGenre(ArtistGenreModel artistGenre);
        Task<IEnumerable<ArtistGenreModel>> UpdateArtistGenres(IEnumerable<ArtistGenreModel> artistGenres);

        // DELETE
        Task DeleteArtistGenre(ArtistGenreModel artistGenre);
        Task DeleteArtistGenres(IEnumerable<ArtistGenreModel> artistGenres);
    }
}
