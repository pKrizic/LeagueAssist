using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class ResultsListViewModel
    {
        public ClubDetailsViewModel homeClub { get; set; }
        public ClubDetailsViewModel guestClub { get; set; }
        public int homeGoals { get; set; }
        public int guestGoals { get; set; }
    }
}
