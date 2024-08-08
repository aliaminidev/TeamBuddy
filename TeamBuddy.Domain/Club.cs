using System;
using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class Club : BaseDomainEntity<int>
    {
        // MaxLength : 100
        public string Name { get; set; }

        public DateTime FoundedDate { get; set; }

        public long? ProvinceId { get; set; }
        public BaseData Province { get; set; }

        public long? CityId { get; set; }
        public BaseData City { get; set; }
    }
}
