using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TeamMember;
using TeamBuddy.Application.Features.TeamMember.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TeamMember.Handlers.Queries
{
    public class GetTeamRequestHandler : IRequestHandler<GetTeamMemberRequest, TeamMemberDto>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;

        public GetTeamRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        public async Task<TeamMemberDto> Handle(GetTeamMemberRequest request, CancellationToken cancellationToken)
        {
            var teamMember = await _teamMemberRepository.Get(request.Id);
            return _mapper.Map<TeamMemberDto>(teamMember);
        }
    }
}
