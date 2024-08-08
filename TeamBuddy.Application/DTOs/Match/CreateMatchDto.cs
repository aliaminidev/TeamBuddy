using System;
using TeamBuddy.Application.DTOs.Common;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.Match
{
    public class CreateMatchDto : IMatchDto
    {
        public int TeamId { get; set; }

        public long OpponentId { get; set; }

        public DateTime Date { get; set; }

        public long VenueId { get; set; }

        public MatchResult Result { get; set; }

        public MatchType Type { get; set; }

        public string? Description { get; set; }
    }
}
