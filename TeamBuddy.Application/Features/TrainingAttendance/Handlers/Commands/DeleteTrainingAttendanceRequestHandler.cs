using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands;
using TeamBuddy.Application.Persistence.Contracts;

namespace TeamBuddy.Application.Features.TrainingAttendance.Handlers.Commands
{
    public class DeleteTrainingAttendanceRequestHandler : IRequestHandler<DeleteTrainingAttendanceRequest>
    {
        private readonly ITrainingAttendanceRepository _trainingAttendanceRepository;

        public DeleteTrainingAttendanceRequestHandler(ITrainingAttendanceRepository trainingAttendanceRepository)
        {
            _trainingAttendanceRepository = trainingAttendanceRepository;
        }

        public async Task Handle(DeleteTrainingAttendanceRequest request, CancellationToken cancellationToken)
        {
            var trainingAttendance = await _trainingAttendanceRepository.Get(request.Id);
            await _trainingAttendanceRepository.Delete(trainingAttendance);
        }
    }
}
