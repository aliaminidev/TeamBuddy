using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Team.Validators;
using TeamBuddy.Application.DTOs.TrainingAttendance;
using TeamBuddy.Application.DTOs.TrainingAttendance.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingAttendance.Handlers.Commands
{
    public class UpdateTrainingAttendanceRequestHandler : IRequestHandler<UpdateTrainingAttendanceRequest>
    {
        private readonly ITrainingAttendanceRepository _trainingAttendanceRepository;
        private readonly IMapper _mapper;
        private readonly ITrainingSessionRepository _trainingSessionRepository;

        public UpdateTrainingAttendanceRequestHandler(ITrainingAttendanceRepository trainingAttendanceRepository, IMapper mapper,
            ITrainingSessionRepository trainingSessionRepository)
        {
            _trainingAttendanceRepository = trainingAttendanceRepository;
            _mapper = mapper;
            _trainingSessionRepository = trainingSessionRepository;
        }

        public async Task Handle(UpdateTrainingAttendanceRequest request, CancellationToken cancellationToken)
        {
            var trainingAttendance = await _trainingAttendanceRepository.Get(request.UpdateTrainingAttendanceDto.Id)
                ?? throw new NotFoundException(nameof(Domain.TrainingAttendance), request.UpdateTrainingAttendanceDto.Id);

            var validator = new UpdateTrainingAttendanceDtoValidator(_trainingSessionRepository, trainingAttendance.TraningSessionId);
            var validationResult = await validator.ValidateAsync(request.UpdateTrainingAttendanceDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            _mapper.Map(request.UpdateTrainingAttendanceDto, trainingAttendance);
            await _trainingAttendanceRepository.Update(trainingAttendance);
        }
    }
}
