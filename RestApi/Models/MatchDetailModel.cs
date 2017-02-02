using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class MatchDetailModel
    {
        
        [Required]
        [Display(Name = "matchId")]
        public string matchId { get; set; }
    }
}