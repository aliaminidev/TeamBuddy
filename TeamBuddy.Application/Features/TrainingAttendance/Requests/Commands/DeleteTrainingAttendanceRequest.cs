using MediatR;

namespace TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands
{
    public class DeleteTrainingAttendanceRequest : IRequest
    {
        public long Id { get; set; }
    }
}
