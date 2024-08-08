using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.Match;

namespace TeamBuddy.Application.Features.Match.Requests.Queries
{
    public class GetMatchListRequest : IRequest<List<MatchDto>>
    {
    }
}
