using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.Club;
using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.Team
{
    public class TeamDto : BaseDto<int>, ITeamDto
    {
        public int ClubId { get; set; }
        public ClubDto Club { get; set; }

        public string Name { get; set; }

        public long SportId { get; set; }
        public BaseDataDto Sport { get; set; }

        public long? StadiumId { get; set; }
        public BaseDataDto Stadium { get; set; }
    }
}
