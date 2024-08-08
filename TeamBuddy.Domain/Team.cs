using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class Team : BaseDomainEntity<int>
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }

        // MaxLength : 100
        public string Name { get; set; }

        public long SportId { get; set; }
        public BaseData Sport { get; set; }

        public long? StadiumId { get; set; }
        public BaseData Stadium { get; set; }
    }
}
