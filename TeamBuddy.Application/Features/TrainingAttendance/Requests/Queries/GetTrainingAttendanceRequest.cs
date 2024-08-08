using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance;

namespace TeamBuddy.Application.Features.TrainingAttendance.Requests.Queries
{
    public class GetTrainingAttendanceRequest : IRequest<TrainingAttendanceDto>
    {
        public long Id { get; set; }
    }
}
