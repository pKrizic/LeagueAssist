using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class ClubDetailsViewModel
    {
        public int id { get; protected set; }
        public string name { get; set; }
        public StadiumDetailsViewModel stadium { get; set; }
        public CityDetailsViewModel city { get; set; }
    }
}
