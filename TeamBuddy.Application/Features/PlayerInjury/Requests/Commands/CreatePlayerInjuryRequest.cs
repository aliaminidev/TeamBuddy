using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;

namespace TeamBuddy.Application.Features.PlayerInjury.Requests.Commands
{
    public class CreatePlayerInjuryRequest : IRequest<int>
    {
        public CreatePlayerInjuryDto CreatePlayerInjuryDto { get; set; }
    }
}
