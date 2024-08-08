using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.Team;

namespace TeamBuddy.Application.Features.Team.Requests.Queries
{
    public class GetTeamListRequest : IRequest<List<TeamDto>>
    {
    }
}
