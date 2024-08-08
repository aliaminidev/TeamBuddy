using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance;
using TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingAttendance.Handlers.Commands
{
    public class UpdateTrainingAttendanceRequestHandler : IRequestHandler<UpdateTrainingAttendanceRequest>
    {
        private readonly ITrainingAttendanceRepository _trainingAttendanceRepository;
        private readonly IMapper _mapper;

        public UpdateTrainingAttendanceRequestHandler(ITrainingAttendanceRepository trainingAttendanceRepository, IMapper mapper)
        {
            _trainingAttendanceRepository = trainingAttendanceRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateTrainingAttendanceRequest request, CancellationToken cancellationToken)
        {
            var trainingAttendance = await _trainingAttendanceRepository.Get(request.UpdateTrainingAttendanceDto.Id);
            _mapper.Map(request.UpdateTrainingAttendanceDto, trainingAttendance);
            await _trainingAttendanceRepository.Update(trainingAttendance);
        }
    }
}
