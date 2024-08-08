using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;
using TeamBuddy.Application.Features.PlayerInjury.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerInjury.Handlers.Commands
{
    public class UpdatePlayerInjuryRequestHandler : IRequestHandler<UpdatePlayerInjuryRequest>
    {
        private readonly IPlayerInjuryRepository _playerInjuryRepository;
        private readonly IMapper _mapper;

        public UpdatePlayerInjuryRequestHandler(IPlayerInjuryRepository playerInjuryRepository, IMapper mapper)
        {
            _playerInjuryRepository = playerInjuryRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdatePlayerInjuryRequest request, CancellationToken cancellationToken)
        {
            var playerInjury = await _playerInjuryRepository.Get(request.UpdatePlayerInjuryDto.Id);
            _mapper.Map(request.UpdatePlayerInjuryDto, playerInjury);
            await _playerInjuryRepository.Update(playerInjury);
        }
    }
}
