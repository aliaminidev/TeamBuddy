using MediatR;
using TeamBuddy.Application.DTOs.TeamMember;

namespace TeamBuddy.Application.Features.TeamMember.Requests.Commands
{
    public class CreateTeamMemberRequest : IRequest<int>
    {
        public CreateTeamMemberDto CreateTeamMemberDto { get; set; }
    }
}
