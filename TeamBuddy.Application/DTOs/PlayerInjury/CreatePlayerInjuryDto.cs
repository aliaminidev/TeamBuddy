using System;
using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.PlayerInjury
{
    public class CreatePlayerInjuryDto : IPlayerInjuryDto
    {
        public int PlayerId { get; set; }

        public long InjuryTypeId { get; set; }

        public DateTime DateTime { get; set; }

        public int EstimatedRecoveryDuration { get; set; }

        public string? Description { get; set; }
    }
}
