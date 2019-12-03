using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;

namespace MusicApp.Services.Services
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PlaylistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PlaylistModel> CreatePlaylistAsync(PlaylistModel playlist)
        {
            var p = _mapper.Map<PlaylistModel, Playlist>(playlist);
            p = await _unitOfWork.Playlists.AddAsync(p);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Playlist, PlaylistModel>(p);
        }

        public async Task<IEnumerable<PlaylistModel>> CreatePlaylistsAsync(IEnumerable<PlaylistModel> playlists)
        {
            var p = _mapper.Map<IEnumerable<PlaylistModel>, IEnumerable<Playlist>>(playlists);
            p = await _unitOfWork.Playlists.AddRangeAsync(p);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistModel>>(p);
        }

        public async Task DeletePlaylistAsync(PlaylistModel playlist)
        {
            var p = _mapper.Map<PlaylistModel, Playlist>(playlist);
            _unitOfWork.Playlists.Delete(p);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePlaylisysAsync(IEnumerable<PlaylistModel> playlists)
        {
            var p = _mapper.Map<IEnumerable<PlaylistModel>, IEnumerable<Playlist>>(playlists);
            _unitOfWork.Playlists.DeleteRange(p);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<PlaylistModel>> GetAllPlaylistsAsync()
        {
            var p = await _unitOfWork.Playlists.GetAsync();
            return _mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistModel>>(p);
        }

        public async Task<PlaylistModel> GetPlaylistAsync(PlaylistModel playlist)
        {
            //TODO: This one needs to be updated to use filtering
            var p = _mapper.Map<PlaylistModel, Playlist>(playlist);
            p = await _unitOfWork.Playlists.GetByIdAsync(p.PlaylistId);
            return _mapper.Map<Playlist, PlaylistModel>(p);
        }

        public async Task<PlaylistModel> GetPlaylistByIdAsync(int id)
        {
            var p = await _unitOfWork.Playlists.GetByIdAsync(id);
            return _mapper.Map<Playlist, PlaylistModel>(p);
        }

        public async Task<PlaylistModel> UpdatePlaylistAsync(PlaylistModel playlist)
        {
            var p = _mapper.Map<PlaylistModel, Playlist>(playlist);
            p = _unitOfWork.Playlists.Update(p);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<Playlist, PlaylistModel>(p);
        }

        public async Task<IEnumerable<PlaylistModel>> UpdatePlaylistsAsync(IEnumerable<PlaylistModel> playlists)
        {
            var p = _mapper.Map<IEnumerable<PlaylistModel>, IEnumerable<Playlist>>(playlists);
            p = _unitOfWork.Playlists.UpdateRange(p);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<Playlist>, IEnumerable<PlaylistModel>>(p);
        }
    }
}
