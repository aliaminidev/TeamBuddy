using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury.Validators;
using TeamBuddy.Application.DTOs.PlayerMatchPerformance.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.PlayerMatchPerformance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.PlayerMatchPerformance.Handlers.Commands
{
    public class CreatePlayerMatchPerformanceRequestHandler : IRequestHandler<CreatePlayerMatchPerformanceRequest, long>
    {
        private readonly IPlayerMatchPerformanceRepository _playerMatchPerformanceRepository;
        private readonly IMapper _mapper;
        private readonly IMatchRepository _matchRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreatePlayerMatchPerformanceRequestHandler
            (IPlayerMatchPerformanceRepository playerMatchPerformanceRepository, IMapper mapper,
            IMatchRepository matchRepository, ITeamMemberRepository teamMemberRepository, IBaseDataRepository baseDataRepository)
        {
            _playerMatchPerformanceRepository = playerMatchPerformanceRepository;
            _mapper = mapper;
            _matchRepository = matchRepository;
            _teamMemberRepository = teamMemberRepository;
            _baseDataRepository = baseDataRepository;
        }

        public async Task<long> Handle(CreatePlayerMatchPerformanceRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreatePlayerMatchPerformanceDtoValidator(_matchRepository, _teamMemberRepository, _baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.CreatePlayerMatchPerformanceDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var playerMatchPerformance = _mapper.Map<Domain.PlayerMatchPerformance>(request.CreatePlayerMatchPerformanceDto);
            playerMatchPerformance = await _playerMatchPerformanceRepository.Add(playerMatchPerformance);
            return playerMatchPerformance.Id;
        }
    }
}
