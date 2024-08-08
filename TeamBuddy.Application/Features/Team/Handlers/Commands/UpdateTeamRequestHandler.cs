using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Team;
using TeamBuddy.Application.Features.Team.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Team.Handlers.Commands
{
    public class UpdateTeamRequestHandler : IRequestHandler<UpdateTeamRequest>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public UpdateTeamRequestHandler(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTeamRequest request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.Get(request.UpdateTeamDto.Id);
            _mapper.Map(request.UpdateTeamDto, team);
            await _teamRepository.Update(team);
        }
    }
}
