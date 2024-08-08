using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.TeamMember
{
    public class UpdateTeamMemberDto : BaseDto<int>, ITeamMemberDto
    {
        public TeamMemberType MemberType { get; set; }
    }
}
