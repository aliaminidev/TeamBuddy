using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Queries
{
    public class GetPlayerMatchPerformanceListRequest : IRequest<List<PlayerMatchPerformanceDto>>
    {
    }
}
