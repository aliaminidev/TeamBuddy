using System;
using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.Club
{
    public class CreateClubDto : IClubDto
    {
        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public long? ProvinceId { get; set; }

        public long? CityId { get; set; }
    }
}
