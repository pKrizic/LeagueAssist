using LeagueAssist;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class MatchDataInsertModel
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "HomeGoals")]
        public string HomeGoals { get; set; }

        [Required]
        [Display(Name = "AwayGoals")]
        public string AwayGoals { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "MatchActions")]
        public List<MatchActions> MatchActions { get; set; }   

    }

//    public class MatchActions
//    {
//        public int PlayerId { get; set; }
//        public int ActivityId { get; set; }
//        public int MatchMinute { get; set; }
    
//    }
}