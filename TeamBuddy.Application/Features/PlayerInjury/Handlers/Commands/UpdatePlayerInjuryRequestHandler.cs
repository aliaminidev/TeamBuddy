using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury;
using TeamBuddy.Application.DTOs.PlayerInjury.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.PlayerInjury.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerInjury.Handlers.Commands
{
    public class UpdatePlayerInjuryRequestHandler : IRequestHandler<UpdatePlayerInjuryRequest>
    {
        private readonly IPlayerInjuryRepository _playerInjuryRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdatePlayerInjuryRequestHandler(IPlayerInjuryRepository playerInjuryRepository, IMapper mapper, IBaseDataRepository baseDataRepository)
        {
            _playerInjuryRepository = playerInjuryRepository;
            _mapper = mapper;
            _baseDataRepository = baseDataRepository;
        }

        public async Task Handle(UpdatePlayerInjuryRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePlayerInjuryDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.UpdatePlayerInjuryDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var playerInjury = await _playerInjuryRepository.Get(request.UpdatePlayerInjuryDto.Id)
                ?? throw new NotFoundException(nameof(Domain.PlayerInjury), request.UpdatePlayerInjuryDto.Id);

            _mapper.Map(request.UpdatePlayerInjuryDto, playerInjury);
            await _playerInjuryRepository.Update(playerInjury);
        }
    }
}
