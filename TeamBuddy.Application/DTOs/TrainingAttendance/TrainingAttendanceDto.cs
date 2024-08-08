using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Application.DTOs.TeamMember;
using TeamBuddy.Application.DTOs.TrainingSession;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.TrainingAttendance
{
    public class TrainingAttendanceDto : BaseDto<long>, ITrainingAttendanceDto
    {
        public int TraningSessionId { get; set; }
        public TrainingSessionDto TrainingSession { get; set; }

        public int PlayerId { get; set; }
        public TeamMemberDto Player { get; set; }

        public TrainingAttendanceStatus Status { get; set; }

        public int AttendanceDuration { get; set; }

        public string? Description { get; set; }
    }
}
