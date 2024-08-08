using MediatR;
using TeamBuddy.Application.DTOs.Team;

namespace TeamBuddy.Application.Features.Team.Requests.Queries
{
    public class GetTeamRequest : IRequest<TeamDto>
    {
        public int Id { get; set; }
    }
}
