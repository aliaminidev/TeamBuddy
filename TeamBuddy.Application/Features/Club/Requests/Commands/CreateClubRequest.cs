using MediatR;
using TeamBuddy.Application.DTOs.Club;

namespace TeamBuddy.Application.Features.Club.Requests.Commands
{
    public class CreateClubRequest : IRequest<int>
    {
        public CreateClubDto CreateClubDto { get; set; }
    }
}
