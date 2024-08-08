using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.Application.DTOs.BaseData
{
    public interface IBaseDataDto
    {
        public string Name { get; set; }

        public string? Description { get; set; }

        public long? ParentId { get; set; }
    }
}
