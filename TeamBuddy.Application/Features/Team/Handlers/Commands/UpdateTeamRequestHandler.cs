using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Match.Validators;
using TeamBuddy.Application.DTOs.Team;
using TeamBuddy.Application.DTOs.Team.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.Team.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.Team.Handlers.Commands
{
    public class UpdateTeamRequestHandler : IRequestHandler<UpdateTeamRequest>
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateTeamRequestHandler(ITeamRepository teamRepository, IMapper mapper, IBaseDataRepository baseDataRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _baseDataRepository = baseDataRepository;
        }

        public async Task Handle(UpdateTeamRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTeamDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateTeamDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var team = await _teamRepository.Get(request.UpdateTeamDto.Id)
                ?? throw new NotFoundException(nameof(Domain.Team), request.UpdateTeamDto.Id);

            _mapper.Map(request.UpdateTeamDto, team);
            await _teamRepository.Update(team);
        }
    }
}
