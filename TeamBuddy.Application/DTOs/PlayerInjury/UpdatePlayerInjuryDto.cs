using System;
using TeamBuddy.Application.DTOs.Common;

namespace TeamBuddy.Application.DTOs.PlayerInjury
{
    public class UpdatePlayerInjuryDto : BaseDto<int>, IPlayerInjuryDto
    {
        public long InjuryTypeId { get; set; }

        public DateTime DateTime { get; set; }

        public int EstimatedRecoveryDuration { get; set; }

        public string? Description { get; set; }
    }
}
