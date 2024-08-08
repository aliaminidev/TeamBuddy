using System;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.TrainingSession
{
    public class UpdateTrainingSessionDto : BaseDto<int>, ITrainingSessionDto
    {
        public DateTime DateTime { get; set; }

        public long LocationId { get; set; }

        public int Duration { get; set; }
    }
}
