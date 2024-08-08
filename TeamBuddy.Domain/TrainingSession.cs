using System;
using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class TrainingSession : BaseDomainEntity<int>
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public DateTime DateTime { get; set; }

        public long LocationId { get; set; }
        public BaseData Location { get; set; }

        // به دقیقه
        public int Duration { get; set; }
    }
}
