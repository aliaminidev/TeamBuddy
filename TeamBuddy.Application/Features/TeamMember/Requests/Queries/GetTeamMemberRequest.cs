using MediatR;
using TeamBuddy.Application.DTOs.TeamMember;

namespace TeamBuddy.Application.Features.TeamMember.Requests.Queries
{
    public class GetTeamMemberRequest : IRequest<TeamMemberDto>
    {
        public int Id { get; set; }
    }
}
