using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class TrainingAttendance : BaseDomainEntity<long>
    {
        public int TraningSessionId { get; set; }
        public TrainingSession TrainingSession { get; set; }

        public int PlayerId { get; set; }
        public TeamMember Player { get; set; }

        public TrainingAttendanceStatus Status { get; set; }

        // به دقیقه
        public int AttendanceDuration { get; set; }

        // MaxLength : 5000
        public string? Description { get; set; }
    }

    public enum TrainingAttendanceStatus
    {
        // موجه
        Present,
        ExcusedAbsent,
        ExcusedLate,

        // غیرموجه
        Absent,
        Late,
    }
}
