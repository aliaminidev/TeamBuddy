using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TeamMember;
using TeamBuddy.Application.Features.TeamMember.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TeamMember.Handlers.Queries
{
    public class GetTeamListRequestHandler : IRequestHandler<GetTeamMemberListRequest, List<TeamMemberDto>>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;

        public GetTeamListRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        public async Task<List<TeamMemberDto>> Handle(GetTeamMemberListRequest request, CancellationToken cancellationToken)
        {
            var teamMemberList = await _teamMemberRepository.GetAll();
            return _mapper.Map<List<TeamMemberDto>>(teamMemberList);
        }
    }
}
