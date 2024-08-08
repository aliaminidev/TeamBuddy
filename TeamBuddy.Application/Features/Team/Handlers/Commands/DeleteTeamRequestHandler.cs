using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.Team.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Team.Handlers.Commands
{
    public class DeleteTeamRequestHandler : IRequestHandler<DeleteTeamRequest>
    {
        private readonly ITeamRepository _teamRepository;

        public DeleteTeamRequestHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task Handle(DeleteTeamRequest request, CancellationToken cancellationToken)
        {
            var team = await _teamRepository.Get(request.Id);
            await _teamRepository.Delete(team);
        }
    }
}
