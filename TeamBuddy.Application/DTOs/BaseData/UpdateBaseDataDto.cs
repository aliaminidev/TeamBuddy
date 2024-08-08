using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.BaseData
{
    public class UpdateBaseDataDto : BaseDto<long>, IBaseDataDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public long? ParentId { get; set; }
    }
}
