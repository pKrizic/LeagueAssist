using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueAssistWeb.Models
{
    public class FixtureResultViewModel
    {
        public int matchId { get; set; }
        public string homeClub { get; set; }
        public string guestClub { get; set; }
        public int? homeGoals { get; set; }
        public int? guestGoals { get; set; }
        
    }
}