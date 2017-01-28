using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace LeagueAssistWeb.Models
{
    public class MatchListViewModel
    {
        public int id { get; set; }
        public string season_Id { get; set; }
        public List<ResultsListViewModel> result { get; set; }
    }
}
