using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.Club;

namespace TeamBuddy.Application.Features.Club.Requests.Queries
{
    public class GetClubListRequest : IRequest<List<ClubDto>>
    {
    }
}
