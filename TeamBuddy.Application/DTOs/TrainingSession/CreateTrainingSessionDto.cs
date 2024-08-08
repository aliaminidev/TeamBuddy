using System;
using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.TrainingSession
{
    public class CreateTrainingSessionDto : ITrainingSessionDto
    {
        public int TeamId { get; set; }

        public DateTime DateTime { get; set; }

        public long LocationId { get; set; }

        public int Duration { get; set; }
    }
}
