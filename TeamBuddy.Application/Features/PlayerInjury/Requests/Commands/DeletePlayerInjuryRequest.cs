using MediatR;

namespace TeamBuddy.Application.Features.PlayerInjury.Requests.Commands
{
    public class DeletePlayerInjuryRequest : IRequest
    {
        public int Id { get; set; }
    }
}
