using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;

namespace TeamBuddy.Application.Features.PlayerInjury.Requests.Queries
{
    public class GetPlayerInjuryRequest : IRequest<PlayerInjuryDto>
    {
        public int Id { get; set; }
    }
}
