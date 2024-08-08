using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Team;
using TeamBuddy.Application.Features.Team.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Team.Handlers.Queries
{
    public class GetTeamRequestHandler : IRequestHandler<GetTeamRequest, TeamDto>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public GetTeamRequestHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task<TeamDto> Handle(GetTeamRequest request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.Get(request.Id);
            return _mapper.Map<TeamDto>(team);
        }
    }
}
