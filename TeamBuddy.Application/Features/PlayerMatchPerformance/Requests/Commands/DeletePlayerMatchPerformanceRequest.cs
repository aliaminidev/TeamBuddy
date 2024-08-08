using MediatR;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands
{
    public class DeletePlayerMatchPerformanceRequest : IRequest
    {
        public long Id { get; set; }
    }
}
