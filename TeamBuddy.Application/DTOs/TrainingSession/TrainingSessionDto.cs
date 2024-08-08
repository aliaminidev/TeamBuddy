using System;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Application.DTOs.Team;

namespace TeamBuddy.Application.DTOs.TrainingSession
{
    public class TrainingSessionDto : BaseDto<int>, ITrainingSessionDto
    {
        public int TeamId { get; set; }
        public TeamDto Team { get; set; }

        public DateTime DateTime { get; set; }

        public long LocationId { get; set; }
        public BaseDataDto Location { get; set; }

        public int Duration { get; set; }
    }
}
