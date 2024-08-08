using System;
using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class PlayerInjury : BaseDomainEntity<int>
    {
        public int PlayerId { get; set; }
        public TeamMember Player { get; set; }

        public long InjuryTypeId {  get; set; }
        public BaseData InjuryType { get; set; }

        public DateTime DateTime { get; set; }

        // به روز
        public int EstimatedRecoveryDuration { get; set; }

        // MaxLength : 5000
        public string? Description { get; set; }
    }
}
