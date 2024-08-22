using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.PlayerInjury.Validators;
using TeamBuddy.Application.DTOs.Team.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.Team.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Team.Handlers.Commands
{
    public class CreateTeamRequestHandler : IRequestHandler<CreateTeamRequest, int>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IClubRepository _clubRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateTeamRequestHandler(ITeamRepository teamRepository, IMapper mapper,
            IClubRepository clubRepository, IBaseDataRepository baseDataRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _clubRepository = clubRepository;
            _baseDataRepository = baseDataRepository;
        }

        public async Task<int> Handle(CreateTeamRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateTeamDtoValidator(_clubRepository, _baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTeamDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var team = _mapper.Map<Domain.Team>(request.CreateTeamDto);
            team = await _teamRepository.Add(team);
            return team.Id;
        }
    }
}
