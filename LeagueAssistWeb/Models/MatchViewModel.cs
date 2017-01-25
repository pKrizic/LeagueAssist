using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class MatchListViewModel
    {
        public int id { get; set; }
        public List<ResultsListViewModel> result { get; set; }
    }
}
