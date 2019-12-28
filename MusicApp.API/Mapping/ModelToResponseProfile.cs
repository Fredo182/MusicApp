using System;
using AutoMapper;
using MusicApp.API.Contracts.V1.Responses.AlbumsReponses;
using MusicApp.API.Contracts.V1.Responses.ArtistsResponses;
using MusicApp.API.Contracts.V1.Responses.SongsReponses;
using MusicApp.Services.Models;

namespace MusicApp.API.Mapping
{
    public class ModelToResponseProfile : Profile
    {
        public ModelToResponseProfile()
        {
            // Artists Mappings
            CreateMap<ArtistModel, ArtistResponse>();
            CreateMap<ArtistModel, ArtistAlbumsResponse>();
            CreateMap<ArtistModel, ArtistAlbumsSongsResponse>();

            // Albums Mappings
            CreateMap<AlbumModel, AlbumResponse>();
            CreateMap<AlbumModel, AlbumSongsResponse>();

            // Songs Mappings
            CreateMap<SongModel, SongResponse>();
        }
    }
}
