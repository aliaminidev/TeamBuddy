using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;
using TeamBuddy.Application.Features.PlayerInjury.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerInjury.Handlers.Queries
{
    public class GetPlayerInjuryRequestHandler : IRequestHandler<GetPlayerInjuryRequest, PlayerInjuryDto>
    {
        private readonly IPlayerInjuryRepository _playerInjuryRepository;
        private readonly IMapper _mapper;

        public GetPlayerInjuryRequestHandler(IPlayerInjuryRepository playerInjuryRepository, IMapper mapper)
        {
            _playerInjuryRepository = playerInjuryRepository;
            _mapper = mapper;
        }

        public async Task<PlayerInjuryDto> Handle(GetPlayerInjuryRequest request, CancellationToken cancellationToken)
        {
            var playerInjury = await _playerInjuryRepository.Get(request.Id);
            return _mapper.Map<PlayerInjuryDto>(playerInjury);
        }
    }
}
