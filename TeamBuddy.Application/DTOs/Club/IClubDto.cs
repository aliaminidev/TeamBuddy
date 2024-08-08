using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.Application.DTOs.Club
{
    public interface IClubDto
    {
        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public long? ProvinceId { get; set; }

        public long? CityId { get; set; }
    }
}
