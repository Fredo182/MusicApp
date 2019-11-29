using System;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Services.Models;

namespace MusicApp.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Domain to Model
            CreateMap<Album, AlbumModel>();
            CreateMap<ArtistGenre, ArtistGenreModel>();
            CreateMap<Artist, ArtistModel>();
            CreateMap<Genre, GenreModel>();
            CreateMap<Song, SongModel>();

            // Model to Domain
            CreateMap<AlbumModel, Album>();
            CreateMap<ArtistGenreModel, ArtistGenre>();
            CreateMap<ArtistModel, Artist>();
            CreateMap<GenreModel, Genre>();
            CreateMap<SongModel, Song>();
        }
    }
}
