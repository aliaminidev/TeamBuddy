using System;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Application.DTOs.TeamMember;

namespace TeamBuddy.Application.DTOs.PlayerInjury
{
    public class PlayerInjuryDto : BaseDto<int>, IPlayerInjuryDto
    {
        public int PlayerId { get; set; }
        public TeamMemberDto Player { get; set; }

        public long InjuryTypeId { get; set; }
        public BaseDataDto InjuryType { get; set; }

        public DateTime DateTime { get; set; }

        public int EstimatedRecoveryDuration { get; set; }

        public string? Description { get; set; }
    }
}
