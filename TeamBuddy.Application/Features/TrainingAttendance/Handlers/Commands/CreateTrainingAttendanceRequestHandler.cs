using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingAttendance.Handlers.Commands
{
    public class CreateTrainingAttendanceRequestHandler : IRequestHandler<CreateTrainingAttendanceRequest, long>
    {
        private readonly ITrainingAttendanceRepository _trainingAttendanceRepository;
        private readonly IMapper _mapper;

        public CreateTrainingAttendanceRequestHandler(ITrainingAttendanceRepository trainingAttendanceRepository, IMapper mapper)
        {
            _trainingAttendanceRepository = trainingAttendanceRepository;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateTrainingAttendanceRequest request, CancellationToken cancellationToken)
        {
            var trainingAttendance = _mapper.Map<Domain.TrainingAttendance>(request.CreateTrainingAttendanceDto);
            trainingAttendance = await _trainingAttendanceRepository.Add(trainingAttendance);
            return trainingAttendance.Id;
        }
    }
}
