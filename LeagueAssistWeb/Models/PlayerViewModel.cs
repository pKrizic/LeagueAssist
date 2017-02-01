using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using LeagueAssist.Entities;

namespace LeagueAssistWeb.Models
{
    public class PlayerListViewModel
    {
        public int id { get; set; }
        [Display(Name = "Ime")]
        public string firstName { get; set; }
        [Display(Name = "Prezime")]
        public string lastName { get; set; }

        public int getId()
        {
            return id;
        }

        public void setId(int _id)
        {
            id = _id;
        }

        public string getFirstName()
        {
            return firstName;
        }

        public void setFirstName(string _firstName)
        {
            firstName = _firstName;
        }

        public string getLastName()
        {
            return lastName;
        }

        public void setLastName(string _lastName)
        {
            lastName = _lastName;
        }
    }

    public class PlayerDetailsViewModel
    {
        public Person player { get; set; }
        public Contract contract { get; set; } 
        public HealthCheckEvidention healthCheck { get; set; }   
    }

    public class PlayersStartSquad
    {
        public MatchPerson matchPlayer { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int numberOnShirt { get; set; }
        public bool isFirstSelection { get; set; }
        public bool isSubstitution { get; set; }
        public bool isCaptain { get; set; }
    }
}
