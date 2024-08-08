using MediatR;
using TeamBuddy.Application.DTOs.Team;

namespace TeamBuddy.Application.Features.Team.Requests.Commands
{
    public class UpdateTeamRequest : IRequest
    {
        public UpdateTeamDto UpdateTeamDto { get; set; }
    }
}
