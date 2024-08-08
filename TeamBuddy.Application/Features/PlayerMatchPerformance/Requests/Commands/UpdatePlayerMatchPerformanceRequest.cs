using MediatR;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands
{
    public class UpdatePlayerMatchPerformanceRequest : IRequest
    {
        public UpdatePlayerMatchPerformanceDto UpdatePlayerMatchPerformanceDto { get; set; }
    }
}
