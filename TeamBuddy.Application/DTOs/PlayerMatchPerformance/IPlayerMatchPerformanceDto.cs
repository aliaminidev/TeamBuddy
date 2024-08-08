using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.PlayerMatchPerformance
{
    public interface IPlayerMatchPerformanceDto
    {
        public PlayerMatchAttendanceStatus Status { get; set; }

        public int AttendanceDuration { get; set; }

        public long? MetricId { get; set; }

        public double? Value { get; set; }

        public string? Description { get; set; }
    }
}
