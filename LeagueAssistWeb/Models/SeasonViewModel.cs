using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class SeasonDetailsViewModel
    {
        public int id { get; protected set; }
        public string season { get; set; }
        public virtual DateTime startDay { get; set; }
        public virtual DateTime endDay { get; set; }
    }
}
