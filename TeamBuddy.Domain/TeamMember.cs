using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class TeamMember : BaseDomainEntity<int>
    {
        //UserId

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public TeamMemberType MemberType { get; set; }
    }

    public enum TeamMemberType
    {
        Player,
        Coach,
        Staff,
        Manager
    }
}
