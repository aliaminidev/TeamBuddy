using MediatR;
using TeamBuddy.Application.DTOs.Match;

namespace TeamBuddy.Application.Features.Match.Requests.Commands
{
    public class UpdateMatchRequest : IRequest
    {
        public UpdateMatchDto UpdateMatchDto { get; set; }
    }
}
