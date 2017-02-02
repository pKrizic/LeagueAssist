using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class CupDetailsViewModel
    {
        public FixtureDetailsViewModel cupPhase { get; protected set; }
        public List<FixtureResultViewModel> result { get; set; }
    }
}
