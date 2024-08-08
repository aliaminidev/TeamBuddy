using MediatR;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Queries
{
    public class GetPlayerMatchPerformanceRequest : IRequest<PlayerMatchPerformanceDto>
    {
        public long Id { get; set; }
    }
}
