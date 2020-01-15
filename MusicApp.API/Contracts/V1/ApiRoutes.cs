using System;
namespace MusicApp.API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Account
        {
            public const string Route = Base + "/account";
            public const string Verb = "account";

            public const string Register = Route + "/register";
            public const string Login = Route + "/login";
            public const string Logout = Route + "/logout";
            public const string Refresh = Route + "/refresh";
            public const string ConfirmEmail = Route + "/email/confirm";
            public const string ChangePassword = Route + "/password/change";
            public const string ForgotPassword = Route + "/password/forgot";
            public const string ResetPassword = Route + "/password/reset";
        }

        public static class Albums
        {
            //base url
            public const string Route = Base + "/albums";
            public const string Verb = "albums";
            public const string Id = "{albumId}";

            //Endpoints
            public const string CreateArtist = Base + "/albums";
            public const string GetArtist = Base + "/albums/{albumId}";
            public const string UpdateArtist = Base + "/albums/{albumId}";
            public const string DeleteArtist = Base + "/albums/{albumId}";
            public const string GetArtists = Base + "/albums";

            //Bulk Endpoints
            public const string CreateArtists = Base + "/albums/bulk";
            public const string DeleteArtists = Base + "/albums/bulk";
            public const string UpdateArtists = Base + "/albums/bulk";
        }

        public static class ArtistGenres
        {
            //base url
            public const string Route = Base + "/artistgenres";
            public const string Verb = "artistgenres";
            public const string Id = "{artistgenreId}";

            //Endpoints
            public const string CreateArtist = Base + "/artistgenres";
            public const string GetArtist = Base + "/artistgenres/{artistgenreId}";
            public const string UpdateArtist = Base + "/artistgenres/{artistgenreId}";
            public const string DeleteArtist = Base + "/artistgenres/{artistgenreId}";
            public const string GetArtists = Base + "/artistgenres";

            //Bulk Endpoints
            public const string CreateArtists = Base + "/artistgenres/bulk";
            public const string DeleteArtists = Base + "/artistgenres/bulk";
            public const string UpdateArtists = Base + "/artistgenres/bulk";
        }

        public static class Artists
        {
            //base url
            public const string Route = Base + "/artists";
            public const string Verb = "artists";
            public const string Id = "{artistId}";

            //Endpoints
            public const string CreateArtist = Base + "/artists";
            public const string GetArtist = Base + "/artists/{artistId}";
            public const string UpdateArtist = Base + "/artists/{artistId}";
            public const string DeleteArtist = Base + "/artists/{artistId}";
            public const string GetArtists = Base + "/artists";

            //Endpoints with includes
            public const string GetArtistAlbums = Base + "/artists/{artistId}/albums";
            public const string GetArtistAlbumsSongs = Base + "/artists/{artistId}/albums/songs";
            public const string GetArtistsAlbums = Base + "/artists/albums";
            public const string GetArtistsAlbumsSongs = Base + "/artists/albums/songs";

            //Bulk Endpoints
            public const string CreateArtists = Base + "/artists/bulk";
            public const string DeleteArtists = Base + "/artists/bulk";
            public const string UpdateArtists = Base + "/artists/bulk";
        }

        public static class Genres
        {
            //base url
            public const string Route = Base + "/genres";
            public const string Verb = "genres";
            public const string Id = "{genreId}";

            //Endpoints
            public const string CreateArtist = Base + "/genres";
            public const string GetArtist = Base + "/genres/{genreId}";
            public const string UpdateArtist = Base + "/genres/{genreId}";
            public const string DeleteArtist = Base + "/genres/{genreId}";
            public const string GetArtists = Base + "/genres";

            //Bulk Endpoints
            public const string CreateArtists = Base + "/genres/bulk";
            public const string DeleteArtists = Base + "/genres/bulk";
            public const string UpdateArtists = Base + "/genres/bulk";
        }

        public static class Songs
        {
            //base url
            public const string Route = Base + "/songs";
            public const string Verb = "songs";
            public const string Id = "{songId}";

            //Endpoints
            public const string CreateArtist = Base + "/songs";
            public const string GetArtist = Base + "/songs/{songId}";
            public const string UpdateArtist = Base + "/songs/{songId}";
            public const string DeleteArtist = Base + "/songs/{songId}";
            public const string GetArtists = Base + "/songs";

            //Bulk Endpoints
            public const string CreateArtists = Base + "/songs/bulk";
            public const string DeleteArtists = Base + "/songs/bulk";
            public const string UpdateArtists = Base + "/songs/bulk";
        }

        public static class Playlists
        {
            //base url
            public const string Route = Base + "/playlists";
            public const string Verb = "playlists";
            public const string Id = "{playlistId}";

            //Endpoints
            public const string CreatePlaylist = Base + "/playlists";
            public const string GetPlaylist = Base + "/playlists/{playlistId}";
            public const string UpdatePlaylist = Base + "/playlists/{playlistId}";
            public const string DeletePlaylist = Base + "/playlists/{playlistId}";
            public const string GetPlaylists = Base + "/playlists";

            //Bulk Endpoints
            public const string CreatePlaylists = Base + "/playlists/bulk";
            public const string DeletePlaylists = Base + "/playlists/bulk";
            public const string UpdatePlaylists = Base + "/playlists/bulk";
        }
    }
}
