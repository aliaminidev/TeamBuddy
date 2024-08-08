using MediatR;

namespace TeamBuddy.Application.Features.Match.Requests.Commands
{
    public class DeleteMatchRequest : IRequest
    {
        public int Id { get; set; }
    }
}
