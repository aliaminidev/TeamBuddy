using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.TeamMember;

namespace TeamBuddy.Application.Features.TeamMember.Requests.Queries
{
    public class GetTeamMemberListRequest : IRequest<List<TeamMemberDto>>
    {
    }
}
