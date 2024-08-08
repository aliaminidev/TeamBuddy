using System;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.Club
{
    public class ClubDto : BaseDto<int>, IClubDto
    {
        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public long? ProvinceId { get; set; }
        public BaseDataDto Province { get; set; }

        public long? CityId { get; set; }
        public BaseDataDto City { get; set; }
    }
}
