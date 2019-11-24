using System;
namespace MusicApp.API.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        //public static class Artists
        //{
        //    //base url
        //    public const string Route = Base + "/artists";
        //    public const string Id = "/{artistId}";

        //    //Endpoints
        //    public const string CreateArtist = Route;
        //    public const string GetArtist = Route + Id;
        //    public const string UpdateArtist = Route + Id;
        //    public const string DeleteArtist = Route + Id;

        //    public const string GetArtists = Route;
        //}
    }
}
