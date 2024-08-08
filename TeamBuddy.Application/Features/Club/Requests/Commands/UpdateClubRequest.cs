using MediatR;
using TeamBuddy.Application.DTOs.Club;

namespace TeamBuddy.Application.Features.Club.Requests.Commands
{
    public class UpdateClubRequest : IRequest
    {
        public UpdateClubDto UpdateClubDto { get; set; }
    }
}
