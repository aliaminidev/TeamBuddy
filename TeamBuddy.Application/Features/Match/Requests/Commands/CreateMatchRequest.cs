using MediatR;
using TeamBuddy.Application.DTOs.Match;

namespace TeamBuddy.Application.Features.Match.Requests.Commands
{
    public class CreateMatchRequest : IRequest<int>
    {
        public CreateMatchDto CreateMatchDto { get; set; }
    }
}
