using MediatR;
using TeamBuddy.Application.DTOs.Match;

namespace TeamBuddy.Application.Features.Match.Requests.Queries
{
    public class GetMatchRequest : IRequest<MatchDto>
    {
        public int Id { get; set; }
    }
}
