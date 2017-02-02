using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class LeagueDetailsViewModel
    {
        public SeasonDetailsViewModel season { get; protected set; }
        public FixtureDetailsViewModel leaguePhase { get; set; }
        public List<FixtureResultViewModel> result { get; set; }
        public List<LeagueClubDetailsViewModel> clubStatus { get; set; }
    }

    public class LeagueClubDetailsViewModel
    {
        public ClubDetailsViewModel club { get; set; }
        public int noOfGames { get; set; }
        public int wins { get; set; }
        public int draws { get; set; }
        public int losses { get; set; }
        public int goalsFor { get; set; }
        public int goalsAgainst { get; set; }
        public int goalsDifference { get; set; }
    }
}
