using System;
namespace MusicApp.Data.Domain.Shared
{
    public class BaseDomain
    {
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public byte[] ConcurrencyStamp { get; set; }

        public DateTimeOffset? ModifiedDateTime { get; set; }

        public DateTimeOffset? CreatedDateTime { get; set; }
    }
}
