using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Match.Validators;
using TeamBuddy.Application.DTOs.PlayerInjury.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.PlayerInjury.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerInjury.Handlers.Commands
{
    public class CreatePlayerInjuryRequestHandler : IRequestHandler<CreatePlayerInjuryRequest, int>
    {
        private readonly IPlayerInjuryRepository _playerInjuryRepository;
        private readonly IMapper _mapper;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreatePlayerInjuryRequestHandler(IPlayerInjuryRepository playerInjuryRepository, IMapper mapper,
            ITeamMemberRepository teamMemberRepository, IBaseDataRepository baseDataRepository)
        {
            _playerInjuryRepository = playerInjuryRepository;
            _mapper = mapper;
            _teamMemberRepository = teamMemberRepository;
            _baseDataRepository = baseDataRepository;
        }

        public async Task<int> Handle(CreatePlayerInjuryRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreatePlayerInjuryDtoValidator(_teamMemberRepository, _baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.CreatePlayerInjuryDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var playerInjury = _mapper.Map<Domain.PlayerInjury>(request.CreatePlayerInjuryDto);
            playerInjury = await _playerInjuryRepository.Add(playerInjury);
            return playerInjury.Id;
        }
    }
}
