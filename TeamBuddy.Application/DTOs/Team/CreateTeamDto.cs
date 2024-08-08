using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.Team
{
    public class CreateTeamDto : ITeamDto
    {
        public int ClubId { get; set; }

        public string Name { get; set; }

        public long SportId { get; set; }

        public long? StadiumId { get; set; }
    }
}
