using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.Team.Validators;
using TeamBuddy.Application.DTOs.TrainingAttendance.Validators;
using TeamBuddy.Application.Exceptions;
using TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingAttendance.Handlers.Commands
{
    public class CreateTrainingAttendanceRequestHandler : IRequestHandler<CreateTrainingAttendanceRequest, long>
    {
        private readonly ITrainingAttendanceRepository _trainingAttendanceRepository;
        private readonly IMapper _mapper;
        private readonly ITrainingSessionRepository _trainingSessionRepository;
        private readonly ITeamMemberRepository _teamMemberRepository;

        public CreateTrainingAttendanceRequestHandler(ITrainingAttendanceRepository trainingAttendanceRepository, IMapper mapper,
            ITrainingSessionRepository trainingSessionRepository, ITeamMemberRepository teamMemberRepository)
        {
            _trainingAttendanceRepository = trainingAttendanceRepository;
            _mapper = mapper;
            _trainingSessionRepository = trainingSessionRepository;
            _teamMemberRepository = teamMemberRepository;
        }

        public async Task<long> Handle(CreateTrainingAttendanceRequest request, CancellationToken cancellationToken)
        {
            var validator = new CreateTrainingAttendanceDtoValidator(_trainingSessionRepository, _teamMemberRepository,
                request.CreateTrainingAttendanceDto.TraningSessionId);
            var validationResult = await validator.ValidateAsync(request.CreateTrainingAttendanceDto);

            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult);
            }

            var trainingAttendance = _mapper.Map<Domain.TrainingAttendance>(request.CreateTrainingAttendanceDto);
            trainingAttendance = await _trainingAttendanceRepository.Add(trainingAttendance);
            return trainingAttendance.Id;
        }
    }
}
