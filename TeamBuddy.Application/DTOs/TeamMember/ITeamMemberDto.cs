using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.TeamMember
{
    public interface ITeamMemberDto
    {
        public TeamMemberType MemberType { get; set; }
    }
}
