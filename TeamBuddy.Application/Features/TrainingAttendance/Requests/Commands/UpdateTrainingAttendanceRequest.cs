using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance;

namespace TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands
{
    public class UpdateTrainingAttendanceRequest : IRequest
    {
        public UpdateTrainingAttendanceDto UpdateTrainingAttendanceDto { get; set; }
    }
}
