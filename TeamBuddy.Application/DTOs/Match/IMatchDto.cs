using System;
using System.Collections.Generic;
using System.Text;
using TeamBuddy.Domain;

namespace TeamBuddy.Application.DTOs.Match
{
    public interface IMatchDto
    {
        public long OpponentId { get; set; }

        public DateTime Date { get; set; }

        public long VenueId { get; set; }

        public MatchResult Result { get; set; }

        public MatchType Type { get; set; }

        public string? Description { get; set; }
    }
}
