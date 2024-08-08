using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.PlayerInjury.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerInjury.Handlers.Commands
{
    public class CreatePlayerInjuryRequestHandler : IRequestHandler<CreatePlayerInjuryRequest, int>
    {
        private readonly IPlayerInjuryRepository _playerInjuryRepository;
        private readonly IMapper _mapper;

        public CreatePlayerInjuryRequestHandler(IPlayerInjuryRepository playerInjuryRepository, IMapper mapper)
        {
            _playerInjuryRepository = playerInjuryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePlayerInjuryRequest request, CancellationToken cancellationToken)
        {
            var playerInjury = _mapper.Map<Domain.PlayerInjury>(request.CreatePlayerInjuryDto);
            playerInjury = await _playerInjuryRepository.Add(playerInjury);
            return playerInjury.Id;
        }
    }
}
