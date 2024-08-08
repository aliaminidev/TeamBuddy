using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance;

namespace TeamBuddy.Application.Features.TrainingAttendance.Requests.Commands
{
    public class CreateTrainingAttendanceRequest : IRequest<long>
    {
        public CreateTrainingAttendanceDto CreateTrainingAttendanceDto { get; set; }
    }
}
