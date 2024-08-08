using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Application.DTOs.Match;
using TeamBuddy.Application.DTOs.TeamMember;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.PlayerMatchPerformance
{
    public class PlayerMatchPerformanceDto : BaseDto<long>, IPlayerMatchPerformanceDto
    {
        public int MatchId { get; set; }
        public MatchDto Match { get; set; }

        public int PlayerId { get; set; }
        public TeamMemberDto Player { get; set; }

        public PlayerMatchAttendanceStatus Status { get; set; }

        public int AttendanceDuration { get; set; }

        public long? MetricId { get; set; }
        public BaseDataDto Metric { get; set; }

        public double? Value { get; set; }

        public string? Description { get; set; }
    }
}
