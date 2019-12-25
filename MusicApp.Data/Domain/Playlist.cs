using System;
using MusicApp.Data.Domain.Shared;

namespace MusicApp.Data.Domain
{
    public class Playlist : BaseDomain
    {
        public int PlaylistId { get; set; }

        public string Name { get; set; }

    }
}
