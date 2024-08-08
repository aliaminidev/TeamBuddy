using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.TrainingAttendance
{
    public class CreateTrainingAttendanceDto : ITrainingAttendanceDto
    {
        public int TraningSessionId { get; set; }

        public int PlayerId { get; set; }

        public TrainingAttendanceStatus Status { get; set; }

        public int AttendanceDuration { get; set; }

        public string? Description { get; set; }
    }
}
