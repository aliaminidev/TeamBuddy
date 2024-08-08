using System.Collections.Generic;
using MediatR;
using TeamBuddy.Application.DTOs.TrainingAttendance;

namespace TeamBuddy.Application.Features.TrainingAttendance.Requests.Queries
{
    public class GetTrainingAttendanceListRequest : IRequest<List<TrainingAttendanceDto>>
    {
    }
}
