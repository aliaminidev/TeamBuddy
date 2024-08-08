using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.Team
{
    public class UpdateTeamDto : BaseDto<int>, ITeamDto
    {
        public string Name { get; set; }

        public long? StadiumId { get; set; }
    }
}
