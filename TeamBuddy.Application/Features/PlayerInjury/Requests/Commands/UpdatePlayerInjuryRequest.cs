using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;

namespace TeamBuddy.Application.Features.PlayerInjury.Requests.Commands
{
    public class UpdatePlayerInjuryRequest : IRequest
    {
        public UpdatePlayerInjuryDto UpdatePlayerInjuryDto { get; set; }
    }
}
