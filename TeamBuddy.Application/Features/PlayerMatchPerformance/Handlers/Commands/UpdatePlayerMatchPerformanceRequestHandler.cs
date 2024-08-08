using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;
using TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Handlers.Commands
{
    public class UpdatePlayerMatchPerformanceRequestHandler : IRequestHandler<UpdatePlayerMatchPerformanceRequest>
    {
        private readonly IPlayerMatchPerformanceRepository _playerMatchPerformanceRepository;
        private readonly IMapper _mapper;

        public UpdatePlayerMatchPerformanceRequestHandler
            (IPlayerMatchPerformanceRepository playerMatchPerformanceRepository, IMapper mapper)
        {
            _playerMatchPerformanceRepository = playerMatchPerformanceRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePlayerMatchPerformanceRequest request, CancellationToken cancellationToken)
        {
            var playerMatchPerformance = await _playerMatchPerformanceRepository.Get(request.UpdatePlayerMatchPerformanceDto.Id);
            _mapper.Map(request.UpdatePlayerMatchPerformanceDto, playerMatchPerformance);
            await _playerMatchPerformanceRepository.Update(playerMatchPerformance);
        }
    }
}
