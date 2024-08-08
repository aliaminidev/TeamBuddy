using MediatR;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands
{
    public class CreatePlayerMatchPerformanceRequest : IRequest<long>
    {
        public CreatePlayerMatchPerformanceDto CreatePlayerMatchPerformanceDto { get; set; }
    }
}
