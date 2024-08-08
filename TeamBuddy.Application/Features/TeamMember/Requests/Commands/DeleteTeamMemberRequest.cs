using MediatR;

namespace TeamBuddy.Application.Features.TeamMember.Requests.Commands
{
    public class DeleteTeamMemberRequest : IRequest
    {
        public int Id { get; set; }
    }
}
