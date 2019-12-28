using System;
namespace MusicApp.Services.Models.Shared
{
    public class BaseModel
    {
        public bool? IsActive { get; set; } = true;

        public bool? IsDeleted { get; set; } = false;

        public byte[] ConcurrencyStamp { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }
}
