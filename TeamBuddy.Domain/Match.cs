using System;
using TeamBuddy.Domain.Common;

namespace TeamBuddy.Domain
{
    public class Match : BaseDomainEntity<int>
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public long OpponentId { get; set; }
        public BaseData Opponent { get; set; }

        public DateTime Date { get; set; }

        public long VenueId { get; set; }
        public BaseData Venue { get; set; }

        public MatchResult Result { get; set; }

        public MatchType Type { get; set; }

        // MaxLength : 5000
        public string? Description { get; set; }
    }

    public enum MatchResult
    {
        // برگزاری مسابقه
        Success,
        Failure,
        Draw,

        // عدم برگزاری مسابقه
        Cancelled,
        Forfeit
    }

    public enum MatchType
    {
        // بازی خانگی
        HomeOfficial,
        HomeUnofficial,

        // بازی غیرخانگی
        AwayOfficial,
        AwayUnofficial,

        // بازی در زمین بی طرف
        NeutralOfficial,
        NeutralUnofficial
    }
}
