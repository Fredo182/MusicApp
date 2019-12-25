using System;
namespace MusicApp.Services.Models.Shared
{
    public class BaseModel
    {
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public byte[] ConcurrencyStamp { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }
}
