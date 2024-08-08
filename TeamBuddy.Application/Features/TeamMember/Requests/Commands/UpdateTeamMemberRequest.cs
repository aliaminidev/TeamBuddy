using MediatR;
using TeamBuddy.Application.DTOs.TeamMember;

namespace TeamBuddy.Application.Features.TeamMember.Requests.Commands
{
    public class UpdateTeamMemberRequest : IRequest
    {
        public UpdateTeamMemberDto UpdateTeamMemberDto { get; set; }
    }
}
