using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.PlayerMatchPerformance
{
    public class UpdatePlayerMatchPerformanceDto : BaseDto<long>, IPlayerMatchPerformanceDto
    {
        public PlayerMatchAttendanceStatus Status { get; set; }

        public int AttendanceDuration { get; set; }

        public long? MetricId { get; set; }

        public double? Value { get; set; }

        public string? Description { get; set; }
    }
}
