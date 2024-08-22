using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TeamMember.Validators;
using TeamBuddy.Application.DTOs.TrainingSession.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.TrainingSession.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingSession.Handlers.Commands
{
    public class CreateTrainingSessionRequestHandler : IRequestHandler<CreateTrainingSessionRequest, int>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly IBaseDataRepository _baseDataRepository;

        public CreateTrainingSessionRequestHandler(ITrainingSessionRepository trainingSessionRepository, IMapper mapper,
            ITeamRepository teamRepository, IBaseDataRepository baseDataRepository)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _mapper = mapper;
            _teamRepository = teamRepository;
            _baseDataRepository = baseDataRepository;
        }

        public async Task<int> Handle(CreateTrainingSessionRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateTrainingSessionDtoValidator(_teamRepository, _baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.CreateTrainingSessionDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var trainingSession = _mapper.Map<Domain.TrainingSession>(request.CreateTrainingSessionDto);
            trainingSession = await _trainingSessionRepository.Add(trainingSession);
            return trainingSession.Id;
        }
    }
}
