using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance.Validators;
using TeamBuddy.Application.DTOs.TrainingSession;
using TeamBuddy.Application.DTOs.TrainingSession.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.TrainingSession.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.Features.TrainingSession.Handlers.Commands
{
    public class UpdateTrainingSessionRequestHandler : IRequestHandler<UpdateTrainingSessionRequest>
    {
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly IMapper _mapper;
        private readonly IBaseDataRepository _baseDataRepository;

        public UpdateTrainingSessionRequestHandler(ITrainingSessionRepository trainingSessionRepository, IMapper mapper, IBaseDataRepository baseDataRepository)
        {
            _trainingSessionRepository = trainingSessionRepository;
            _mapper = mapper;
            _baseDataRepository = baseDataRepository;
        }

        public async Task Handle(UpdateTrainingSessionRequest request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTrainingSessionDtoValidator(_baseDataRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateTrainingSessionDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var trainingSession = await _trainingSessionRepository.Get(request.UpdateTrainingSessionDto.Id)
                ?? throw new NotFoundException(nameof(Domain.TrainingSession), request.UpdateTrainingSessionDto.Id);

            _mapper.Map(request.UpdateTrainingSessionDto, trainingSession);
            await _trainingSessionRepository.Update(trainingSession);
        }
    }
}
