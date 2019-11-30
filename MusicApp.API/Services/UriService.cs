using System;
using Microsoft.AspNetCore.WebUtilities;
using MusicApp.API.Contracts.V1;
using MusicApp.API.Contracts.V1.Requests.Queries;
using MusicApp.API.Services.Interfaces;

namespace MusicApp.API.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetAllArtistsUri(PaginationQuery pagination = null)
        {
            var uri = new Uri(_baseUri);

            if (pagination == null)
            {
                return uri;
            }

            var modifiedUri = QueryHelpers.AddQueryString(_baseUri, "pageNumber", pagination.PageNumber.ToString());
            modifiedUri = QueryHelpers.AddQueryString(modifiedUri, "pageSize", pagination.PageSize.ToString());

            return new Uri(modifiedUri);
        }

        public Uri GetArtistUri(string artistId)
        {
            return new Uri(_baseUri + ApiRoutes.Artists.GetArtist.Replace("aristId", artistId));
        }
    }
}
