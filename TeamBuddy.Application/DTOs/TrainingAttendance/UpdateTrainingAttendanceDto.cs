﻿using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.TrainingAttendance
{
    public class UpdateTrainingAttendanceDto : BaseDto<long>, ITrainingAttendanceDto
    {
        public TrainingAttendanceStatus Status { get; set; }

        public int AttendanceDuration { get; set; }

        public string? Description { get; set; }
    }
}
