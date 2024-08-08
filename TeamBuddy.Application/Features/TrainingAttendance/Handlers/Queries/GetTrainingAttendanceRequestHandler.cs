using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance;
using TeamBuddy.Application.Features.TrainingAttendance.Requests.Queries;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingAttendance.Handlers.Queries
{
    public class GetTrainingAttendanceRequestHandler : IRequestHandler<GetTrainingAttendanceRequest, TrainingAttendanceDto>
    {
        private readonly ITrainingAttendanceRepository _trainingAttendanceRepository;
        private readonly IMapper _mapper;

        public GetTrainingAttendanceRequestHandler(ITrainingAttendanceRepository trainingAttendanceRepository, IMapper mapper)
        {
            _trainingAttendanceRepository = trainingAttendanceRepository;
            _mapper = mapper;
        }

        public async Task<TrainingAttendanceDto> Handle(GetTrainingAttendanceRequest request, CancellationToken cancellationToken)
        {
            var trainingAttendance = await _trainingAttendanceRepository.Get(request.Id);
            return _mapper.Map<TrainingAttendanceDto>(trainingAttendance);
        }
    }
}
