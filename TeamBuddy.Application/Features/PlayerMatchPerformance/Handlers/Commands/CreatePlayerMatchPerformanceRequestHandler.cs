using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Handlers.Commands
{
    public class CreatePlayerMatchPerformanceRequestHandler : IRequestHandler<CreatePlayerMatchPerformanceRequest, long>
    {
        private readonly IPlayerMatchPerformanceRepository _playerMatchPerformanceRepository;
        private readonly IMapper _mapper;

        public CreatePlayerMatchPerformanceRequestHandler
            (IPlayerMatchPerformanceRepository playerMatchPerformanceRepository, IMapper mapper)
        {
            _playerMatchPerformanceRepository = playerMatchPerformanceRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreatePlayerMatchPerformanceRequest request, CancellationToken cancellationToken)
        {
            var playerMatchPerformance = _mapper.Map<Domain.PlayerMatchPerformance>(request.CreatePlayerMatchPerformanceDto);
            playerMatchPerformance = await _playerMatchPerformanceRepository.Add(playerMatchPerformance);
            return playerMatchPerformance.Id;
        }
    }
}
