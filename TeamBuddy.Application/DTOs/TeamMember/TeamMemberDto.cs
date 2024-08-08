using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Application.DTOs.Team;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.TeamMember
{
    public class TeamMemberDto : BaseDto<int>, ITeamMemberDto
    {
        public int TeamId { get; set; }
        public TeamDto Team { get; set; }

        public TeamMemberType MemberType { get; set; }
    }
}
