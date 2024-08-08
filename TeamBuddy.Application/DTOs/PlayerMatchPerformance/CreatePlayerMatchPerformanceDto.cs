using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.PlayerMatchPerformance
{
    public class CreatePlayerMatchPerformanceDto : IPlayerMatchPerformanceDto
    {
        public int MatchId { get; set; }

        public int PlayerId { get; set; }

        public PlayerMatchAttendanceStatus Status { get; set; }

        public int AttendanceDuration { get; set; }

        public long? MetricId { get; set; }

        public double? Value { get; set; }

        public string? Description { get; set; }
    }
}
