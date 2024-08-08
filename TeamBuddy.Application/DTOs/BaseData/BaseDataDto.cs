using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.BaseData
{
    public class BaseDataDto : BaseDto<long>, IBaseDataDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public BaseDataType DataType { get; set; }

        public long? ParentId { get; set; }
        public BaseDataDto Parent { get; set; }
    }
}
