using MediatR;
using TeamBuddy.Application.DTOs.Team;

namespace TeamBuddy.Application.Features.Team.Requests.Commands
{
    public class CreateTeamRequest : IRequest<int>
    {
        public CreateTeamDto CreateTeamDto { get; set; }
    }
}
