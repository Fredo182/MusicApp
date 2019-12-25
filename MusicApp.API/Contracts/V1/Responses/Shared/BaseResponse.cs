using System;
namespace MusicApp.API.Contracts.V1.Responses.Shared
{
    public class BaseResponse
    {
        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        public byte[] ConcurrencyStamp { get; set; }

        public DateTimeOffset ModifiedDateTime { get; set; }

        public DateTimeOffset CreatedDateTime { get; set; }
    }
}
