using System;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Data.Domain.Shared;
using MusicApp.Services.Models;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Mapping
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            //Shared
            CreateMap<PaginationState, PaginationStateModel>();

            // Domain to Model
            CreateMap<Album, AlbumModel>();
            CreateMap<ArtistGenre, ArtistGenreModel>();
            CreateMap<Artist, ArtistModel>();
            CreateMap<Genre, GenreModel>();
            CreateMap<Song, SongModel>();
            CreateMap<Playlist, PlaylistModel>();

        }
    }
}
