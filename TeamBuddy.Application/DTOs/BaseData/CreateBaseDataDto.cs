using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.BaseData
{
    public class CreateBaseDataDto : IBaseDataDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public BaseDataType DataType { get; set; }

        public long? ParentId { get; set; }
    }
}
