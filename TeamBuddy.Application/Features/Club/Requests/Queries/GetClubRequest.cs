using MediatR;
using TeamBuddy.Application.DTOs.Club;

namespace TeamBuddy.Application.Features.Club.Requests.Queries
{
    public class GetClubRequest : IRequest<ClubDto>
    {
        public int Id { get; set; }
    }
}
