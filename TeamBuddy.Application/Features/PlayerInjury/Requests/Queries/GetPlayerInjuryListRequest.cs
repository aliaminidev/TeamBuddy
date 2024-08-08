using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;

namespace TeamBuddy.Application.Features.PlayerInjury.Requests.Queries
{
    public class GetPlayerInjuryListRequest : IRequest<List<PlayerInjuryDto>>
    {
    }
}
