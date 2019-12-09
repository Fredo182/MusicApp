using System;
namespace MusicApp.API.Contracts.V1.Responses.ArtistsResponses
{
    public class ArtistResponse
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        //TODO  Create Responses for the classes below
        //public List<AlbumModel> Albums { get; set; }

        //public List<ArtistGenreModel> ArtistGenres { get; set; }
    }
}
