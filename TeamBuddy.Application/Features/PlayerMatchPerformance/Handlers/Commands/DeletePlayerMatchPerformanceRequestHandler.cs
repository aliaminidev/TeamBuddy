using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Handlers.Commands
{
    public class DeletePlayerMatchPerformanceRequestHandler : IRequestHandler<DeletePlayerMatchPerformanceRequest>
    {
        private readonly IPlayerMatchPerformanceRepository _playerMatchPerformanceRepository;

        public DeletePlayerMatchPerformanceRequestHandler
            (IPlayerMatchPerformanceRepository playerMatchPerformanceRepository)
        {
            _playerMatchPerformanceRepository = playerMatchPerformanceRepository;
        }

        public async Task Handle(DeletePlayerMatchPerformanceRequest request, CancellationToken cancellationToken)
        {
            var playerMatchPerformance = await _playerMatchPerformanceRepository.Get(request.Id)
                ?? throw new NotFoundException(nameof(Domain.PlayerMatchPerformance), request.Id);

            await _playerMatchPerformanceRepository.Delete(playerMatchPerformance);
        }
    }
}
