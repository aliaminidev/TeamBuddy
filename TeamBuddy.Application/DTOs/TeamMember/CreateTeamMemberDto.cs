using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.TeamMember
{
    public class CreateTeamMemberDto : ITeamMemberDto
    {
        public int TeamId { get; set; }

        public TeamMemberType MemberType { get; set; }
    }
}
