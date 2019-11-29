using System;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Services.Models;

namespace MusicApp.Services.Mapping
{
    public class ModelToDomainProfile : Profile
    {
        public ModelToDomainProfile()
        {
            // Model to Domain
            CreateMap<AlbumModel, Album>();
            CreateMap<ArtistGenreModel, ArtistGenre>();
            CreateMap<ArtistModel, Artist>();
            CreateMap<GenreModel, Genre>();
            CreateMap<SongModel, Song>();
        }
    }
}
