using System;
namespace MusicApp.API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Albums
        {
            //base url
            public const string Route = Base + "/albums";
            public const string Id = "/{albumId}";

            //Endpoints
            public const string CreateArtist = Base + "/albums";
            public const string GetArtist = Base + "/albums/{albumId}";
            public const string UpdateArtist = Base + "/albums/{albumId}";
            public const string DeleteArtist = Base + "/albums/{albumId}";

            public const string CreateArtists = Base + "/albums";
            public const string GetArtists = Base + "/albums";
            public const string DeleteArtists = Base + "/albums";
            public const string UpdateArtists = Base + "/albums";
        }

        public static class ArtistGenres
        {
            //base url
            public const string Route = Base + "/artistgenres";
            public const string Id = "/{artistgenreId}";

            //Endpoints
            public const string CreateArtist = Base + "/artistgenres";
            public const string GetArtist = Base + "/artistgenres/{artistgenreId}";
            public const string UpdateArtist = Base + "/artistgenres/{artistgenreId}";
            public const string DeleteArtist = Base + "/artistgenres/{artistgenreId}";

            public const string CreateArtists = Base + "/artistgenres";
            public const string GetArtists = Base + "/artistgenres";
            public const string DeleteArtists = Base + "/artistgenres";
            public const string UpdateArtists = Base + "/artistgenres";
        }

        public static class Artists
        {
            //base url
            public const string Route = Base + "/artists";
            public const string Id = "/{artistId}";

            //Endpoints
            public const string CreateArtist = Base + "/artists";
            public const string GetArtist = Base + "/artists/{artistId}";
            public const string UpdateArtist = Base + "/artists/{artistId}";
            public const string DeleteArtist = Base + "/artists/{artistId}";

            public const string CreateArtists = Base + "/artists";
            public const string GetArtists = Base + "/artists";
            public const string DeleteArtists = Base + "/artists";
            public const string UpdateArtists = Base + "/artists";
        }

        public static class Genres
        {
            //base url
            public const string Route = Base + "/genres";
            public const string Id = "/{genreId}";

            //Endpoints
            public const string CreateArtist = Base + "/genres";
            public const string GetArtist = Base + "/genres/{genreId}";
            public const string UpdateArtist = Base + "/genres/{genreId}";
            public const string DeleteArtist = Base + "/genres/{genreId}";

            public const string CreateArtists = Base + "/genres";
            public const string GetArtists = Base + "/genres";
            public const string DeleteArtists = Base + "/genres";
            public const string UpdateArtists = Base + "/genres";
        }

        public static class Songs
        {
            //base url
            public const string Route = Base + "/songs";
            public const string Id = "/{songId}";

            //Endpoints
            public const string CreateArtist = Base + "/songs";
            public const string GetArtist = Base + "/songs/{songId}";
            public const string UpdateArtist = Base + "/songs/{songId}";
            public const string DeleteArtist = Base + "/songs/{songId}";

            public const string CreateArtists = Base + "/songs";
            public const string GetArtists = Base + "/songs";
            public const string DeleteArtists = Base + "/songs";
            public const string UpdateArtists = Base + "/songs";
        }
    }
}
