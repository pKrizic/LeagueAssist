using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestApi.Models
{
    public class MatchReferee
    {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "BrojUtakmica")]
        public string BrojUtakmica { get; set; }
    }
}