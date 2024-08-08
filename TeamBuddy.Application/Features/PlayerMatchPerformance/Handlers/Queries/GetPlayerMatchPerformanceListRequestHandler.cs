using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance;
using TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Handlers.Queries
{
    public class GetPlayerMatchPerformanceListRequestHandler : IRequestHandler<GetPlayerMatchPerformanceListRequest, List<PlayerMatchPerformanceDto>>
    {
        private readonly IPlayerMatchPerformanceRepository _playerMatchPerformanceRepository;
        private readonly IMapper _mapper;

        public GetPlayerMatchPerformanceListRequestHandler(IPlayerMatchPerformanceRepository playerMatchPerformanceRepository, IMapper mapper)
        {
            _playerMatchPerformanceRepository = playerMatchPerformanceRepository;
            _mapper = mapper;
        }

        public async Task<List<PlayerMatchPerformanceDto>> Handle(GetPlayerMatchPerformanceListRequest request, CancellationToken cancellationToken)
        {
            var playerMatchPerformanceList = await _playerMatchPerformanceRepository.GetAll();
            return _mapper.Map<List<PlayerMatchPerformanceDto>>(playerMatchPerformanceList);
        }
    }
}
