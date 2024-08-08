using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.TeamMember.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TeamMember.Handlers.Commands
{
    public class CreateTeamMemberRequestHandler : IRequestHandler<CreateTeamMemberRequest, int>
    {
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IMapper _mapper;

        public CreateTeamMemberRequestHandler(ITeamMemberRepository teamMemberRepository, IMapper mapper)
        {
            _teamMemberRepository = teamMemberRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTeamMemberRequest request, CancellationToken cancellationToken)
        {
            var teamMember = _mapper.Map<Domain.TeamMember>(request.CreateTeamMemberDto);
            teamMember = await _teamMemberRepository.Add(teamMember);
            return teamMember.Id;
        }
    }
}
