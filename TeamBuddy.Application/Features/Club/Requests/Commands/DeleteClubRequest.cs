using MediatR;

namespace TeamBuddy.Application.Features.Club.Requests.Commands
{
    public class DeleteClubRequest : IRequest
    {
        public int Id { get; set; }
    }
}
