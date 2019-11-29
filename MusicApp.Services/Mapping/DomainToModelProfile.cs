using System;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Services.Models;

namespace MusicApp.Services.Mapping
{
    public class DomainToModelProfile : Profile
    {
        public DomainToModelProfile()
        {
            // Domain to Model
            CreateMap<Album, AlbumModel>();
            CreateMap<ArtistGenre, ArtistGenreModel>();
            CreateMap<Artist, ArtistModel>();
            CreateMap<Genre, GenreModel>();
            CreateMap<Song, SongModel>();

        }
    }
}
