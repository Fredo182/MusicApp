using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MusicApp.Services.Models;

namespace MusicApp.Services.Services.Interfaces
{
    public interface IArtistGenreService
    {
        // CREATE
        Task<ArtistGenreModel> CreateArtistGenreAsync(ArtistGenreModel artistGenre);
        Task<IEnumerable<ArtistGenreModel>> CreateArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres);

        // READ
        Task<ArtistGenreModel> GetArtistGenreByIdAsync(int id);
        Task<ArtistGenreModel> GetArtistGenreAsync(ArtistGenreModel artistGenre);
        Task<IEnumerable<ArtistGenreModel>> GetAllArtistGenresAsync();
        Task<bool> ArtistGenreExistsAsync(int id);

        // UPDATE
        Task<ArtistGenreModel> UpdateArtistGenreAsync(ArtistGenreModel artistGenre);
        Task<IEnumerable<ArtistGenreModel>> UpdateArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres);

        // DELETE
        Task<bool> DeleteArtistGenreAsync(ArtistGenreModel artistGenre);
        Task<bool> DeleteArtistGenreAsync(params object[] id);
        Task DeleteArtistGenresAsync(IEnumerable<ArtistGenreModel> artistGenres);
    }
}
