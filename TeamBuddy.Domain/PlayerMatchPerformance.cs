using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class PlayerMatchPerformance : BaseDomainEntity<long>
    {
        public int MatchId { get; set; }
        public Match Match { get; set; }

        public int PlayerId { get; set; }
        public TeamMember Player { get; set; }

        public PlayerMatchAttendanceStatus Status { get; set; }

        // به دقیقه
        public int AttendanceDuration { get; set; }

        public long? MetricId { get; set; }
        public BaseData Metric { get; set; }

        public double? Value { get; set; }

        // MaxLength : 5000
        public string? Description { get; set; }
    }

    public enum PlayerMatchAttendanceStatus
    {
        // موجه
        Present,
        ExcusedAbsent,
        ExcusedLate,
        Unlisted,

        // غیرموجه
        Absent,
        Late,
    }
}
