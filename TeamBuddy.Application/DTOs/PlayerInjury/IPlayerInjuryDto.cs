using System;
using System.Collections.Generic;
using System.Text;

namespace TeamBuddy.Application.DTOs.PlayerInjury
{
    public interface IPlayerInjuryDto
    {
        public long InjuryTypeId { get; set; }

        public DateTime DateTime { get; set; }

        public int EstimatedRecoveryDuration { get; set; }

        public string? Description { get; set; }
    }
}
