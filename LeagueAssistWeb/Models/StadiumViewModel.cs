using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class StadiumDetailsViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int capacity { get; set; }
        public string address { get; set; }
        public CityDetailsViewModel city { get; set; }
    }
}
