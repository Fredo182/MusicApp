using System;
using MusicApp.Services.Models.Shared;

namespace MusicApp.Services.Models
{
    public class PlaylistModel : BaseModel
    {
        public int PlaylistId { get; set; }

        public string Name { get; set; }
    }
}
