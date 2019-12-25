using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using MusicApp.Data.Domain;
using MusicApp.Data.UnitOfWork.Interfaces;
using MusicApp.Services.Models.Shared;
using MusicApp.Services.Models;
using MusicApp.Services.Services.Interfaces;
using MusicApp.Services.Models.Queries.Shared;
using MusicApp.Data.Domain.Queries.Shared;
using MusicApp.Data.Domain.Queries;
using MusicApp.Services.Models.Queries;
using MusicApp.Data.Helpers;

namespace MusicApp.Services.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArtistService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<ArtistModel> CreateArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = await _unitOfWork.Artists.AddAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<IEnumerable<ArtistModel>> CreateArtistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            a = await _unitOfWork.Artists.AddRangeAsync(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistModel>>(a);
        }

        public async Task<IEnumerable<ArtistModel>> GetArtistsAsync(ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null)
        {
            var f = ArtistFilterExpressions(_mapper.Map<ArtistFilter>(filter));
            var o = ArtistOrderByList(_mapper.Map<IEnumerable<ArtistOrderBy>>(orderByList));
            var a = await _unitOfWork.Artists.GetAsync(f, o);
            return _mapper.Map<IEnumerable<ArtistModel>>(a);
        }

        public async Task<PaginationResultModel<ArtistModel>> GetPagedArtistsAsync(PaginationModel pagination, ArtistFilterModel filter = null, IEnumerable<ArtistOrderByModel> orderByList = null)
        {
            var p = _mapper.Map<Pagination>(pagination);
            var f = ArtistFilterExpressions(_mapper.Map<ArtistFilter>(filter));
            var o = ArtistOrderByList(_mapper.Map<IEnumerable<ArtistOrderBy>>(orderByList));
            var a = await _unitOfWork.Artists.GetPagedAsync(p, f, o);
            var result = new PaginationResultModel<ArtistModel>(_mapper.Map<PaginationStateModel>(a.PageState), _mapper.Map<IEnumerable<ArtistModel>>(a.Result));
            return result;
        }

        public async Task<ArtistModel> GetArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = await _unitOfWork.Artists.GetByIdAsync(a.ArtistId);
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<ArtistModel> GetArtistByIdAsync(int id)
        {
            var a = await _unitOfWork.Artists.GetByIdAsync(id);
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<ArtistModel> UpdateArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            a = _unitOfWork.Artists.Update(a);
            await _unitOfWork.CommitAsync();

            var f = new List<Expression<Func<Artist, bool>>>() { (x => x.ArtistId == a.ArtistId) };
            a = await _unitOfWork.Artists.GetOneAsync(f, null, false);
            return _mapper.Map<ArtistModel>(a);
        }

        public async Task<IEnumerable<ArtistModel>> UpdateArtistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            a = _unitOfWork.Artists.UpdateRange(a);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<IEnumerable<ArtistModel>>(a);
        }

        public async Task<bool> DeleteArtistAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            _unitOfWork.Artists.Delete(a);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task<bool> DeleteArtistAsync(params object[] id)
        {
            _unitOfWork.Artists.Delete(id);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task<bool> DeleteArtistsAsync(int[] ids)
        {
            var f = new List<Expression<Func<Artist, bool>>>() {(x => ids.Contains(x.ArtistId))};
            var a = await _unitOfWork.Artists.GetAsync(f, null, null, false);
            _unitOfWork.Artists.DeleteRange(a);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task<bool> DeleteArtistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            _unitOfWork.Artists.DeleteRange(a);
            var deleted = await _unitOfWork.CommitAsync();
            return deleted > 0;
        }

        public async Task<bool> ArtistIdExistsAsync(int id)
        {
            var f = new List<Expression<Func<Artist, bool>>>() { (x => x.ArtistId == id) };
            return await _unitOfWork.Artists.GetExistsAsync(f, false);
        }

        public async Task<bool> ArtistIdsExistAsync(int[] ids)
        {
            var f = new List<Expression<Func<Artist, bool>>>() { (x => ids.Contains(x.ArtistId)) };
            var a = await _unitOfWork.Artists.GetAsync(f, null, null, false);
            return (a.Count() == ids.Count());
        }

        public async Task<bool> ArtistExistsAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            var f = new List<Expression<Func<Artist, bool>>>() { (x => x.ArtistId == a.ArtistId) };
            return await _unitOfWork.Artists.GetExistsAsync(f, false);
        }

        public async Task<IEnumerable<ArtistModel>> ArtistsExistAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            var ids = a.Select(x => x.ArtistId).ToList();
            var f = new List<Expression<Func<Artist, bool>>>() { (x => ids.Contains(x.ArtistId)) };
            var exist = await _unitOfWork.Artists.GetAsync(f, null, null, false);
            return _mapper.Map<IEnumerable<ArtistModel>>(exist);
        }

        public async Task<IEnumerable<ArtistModel>> ArtistsNotExistAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            var ids = a.Select(x => x.ArtistId).ToList();
            var f = new List<Expression<Func<Artist, bool>>>() { (x => ids.Contains(x.ArtistId)) };
            var exist = await _unitOfWork.Artists.GetAsync(f, null, null, false);
            var existIds = exist.Select(x => x.ArtistId);
            var notExist = a.Where(x => existIds.Contains(x.ArtistId) == false).ToList();
            return _mapper.Map<IEnumerable<ArtistModel>>(notExist);
        }

        public async Task<bool> ArtistNameExistsAsync(string name)
        {
            var f = new List<Expression<Func<Artist, bool>>>() { (x => x.Name == name) };
            return await _unitOfWork.Artists.GetExistsAsync(f, false);
        }

        public async Task<bool> ArtistNameExistsAsync(ArtistModel artist)
        {
            var a = _mapper.Map<Artist>(artist);
            var f = new List<Expression<Func<Artist, bool>>>() { (x => x.Name == a.Name) };
            return await _unitOfWork.Artists.GetExistsAsync(f, false);
        }

        public async Task<IEnumerable<ArtistModel>> ArtistNamesExistsAsync(IEnumerable<ArtistModel> artists)
        {
            var a = _mapper.Map<IEnumerable<Artist>>(artists);
            var names = a.Select(x => x.Name).ToList();
            var f = new List<Expression<Func<Artist, bool>>>() { (x => names.Contains(x.Name)) };
            var exist = await _unitOfWork.Artists.GetAsync(f, null, null, false);
            return _mapper.Map<IEnumerable<ArtistModel>>(exist);
        }

        private List<Expression<Func<Artist, bool>>> ArtistFilterExpressions(ArtistFilter filter)
        {
            List<Expression<Func<Artist, bool>>> filters = new List<Expression<Func<Artist, bool>>>();
            if (filter != null)
            {
                if (filter.ArtistId != null)
                    filters.Add((s => s.ArtistId == filter.ArtistId));

                if (!string.IsNullOrEmpty(filter.Name))
                    filters.Add((s => s.Name == filter.Name));
            }
            return filters;
        }

        private IEnumerable<IOrderByClause<Artist>> ArtistOrderByList(IEnumerable<ArtistOrderBy> artistOrderByList)
        {
            List<IOrderByClause<Artist>> orderBylist = new List<IOrderByClause<Artist>>();
            if (artistOrderByList != null)
            {
                foreach (var orderBy in artistOrderByList)
                {
                    if (orderBy.ArtistId != null)
                        orderBylist.Add(new OrderByClause<Artist, int>(a => a.ArtistId, orderBy.OrderType));
                    else if (orderBy.Name != null)
                        orderBylist.Add(new OrderByClause<Artist, string>(a => a.Name, orderBy.OrderType));
                }
            }
            return orderBylist;
        }


    }
}
