using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;
using TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Handlers.Queries
{
    public class GetPlayerMatchPerformanceRequestHandler : IRequestHandler<GetPlayerMatchPerformanceRequest, PlayerMatchPerformanceDto>
    {
        private readonly IPlayerMatchPerformanceRepository _playerMatchPerformanceRepository;
        private readonly IMapper _mapper;

        public GetPlayerMatchPerformanceRequestHandler(IPlayerMatchPerformanceRepository playerMatchPerformanceRepository, IMapper mapper)
        {
            _playerMatchPerformanceRepository = playerMatchPerformanceRepository;
            _mapper = mapper;
        }

        public async Task<PlayerMatchPerformanceDto> Handle(GetPlayerMatchPerformanceRequest request, CancellationToken cancellationToken)
        {
            var playerMatchPerformance = await _playerMatchPerformanceRepository.Get(request.Id);
            return _mapper.Map<PlayerMatchPerformanceDto>(playerMatchPerformance);
        }
    }
}
