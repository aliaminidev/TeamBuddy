using MediatR;

namespace TeamBuddy.Application.Features.Team.Requests.Commands
{
    public class DeleteTeamRequest : IRequest
    {
        public int Id { get; set; }
    }
}
