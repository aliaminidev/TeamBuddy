using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.PlayerInjury.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerInjury.Handlers.Commands
{
    public class DeletePlayerInjuryRequestHandler : IRequestHandler<DeletePlayerInjuryRequest>
    {
        private readonly IPlayerInjuryRepository _playerInjuryRepository;

        public DeletePlayerInjuryRequestHandler(IPlayerInjuryRepository playerInjuryRepository)
        {
            _playerInjuryRepository = playerInjuryRepository;
        }

        public async Task Handle(DeletePlayerInjuryRequest request, CancellationToken cancellationToken)
        {
            var playerInjury = await _playerInjuryRepository.Get(request.Id)
                ?? throw new NotFoundException(nameof(Domain.PlayerInjury), request.Id);

            await _playerInjuryRepository.Delete(playerInjury);
        }
    }
}
