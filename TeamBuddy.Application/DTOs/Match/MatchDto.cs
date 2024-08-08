using System;
using TeamBuddy.Application.DTOs.BaseData;
using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Application.DTOs.Team;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.Match
{
    public class MatchDto : BaseDto<int>, IMatchDto
    {
        public int TeamId { get; set; }
        public TeamDto Team { get; set; }

        public long OpponentId { get; set; }
        public BaseDataDto Opponent { get; set; }

        public DateTime Date { get; set; }

        public long VenueId { get; set; }
        public BaseDataDto Venue { get; set; }

        public MatchResult Result { get; set; }

        public MatchType Type { get; set; }

        public string? Description { get; set; }
    }
}
