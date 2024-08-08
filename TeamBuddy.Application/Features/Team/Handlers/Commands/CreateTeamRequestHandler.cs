using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.Team.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Team.Handlers.Commands
{
    public class CreateTeamRequestHandler : IRequestHandler<CreateTeamRequest, int>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public CreateTeamRequestHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateTeamRequest request, CancellationToken cancellationToken)
        {
            var team = _mapper.Map<Domain.Team>(request.CreateTeamDto);
            team = await _teamRepository.Add(team);
            return team.Id;
        }
    }
}
