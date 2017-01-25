using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        public int id { get; set; }
        [Display(Name = "Ime")]
        public string firstName { get; set; }
        [Display(Name = "Prezime")]
        public string lastName { get; set; }
        [Display(Name = "Datum rođenja")]
        public DateTime? birthDate { get; set; }
        [Display(Name = "Email")]
        public string email { get; set; }
        [Display(Name = "Telefon")]
        public string phone { get; set; }
        public ContractViewModel contract { get; set; } 
        public HealthCheckViewModel healthCheck { get; set; }
        
    }

    public class ContractViewModel
    {
        public int? id { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
        public bool foreigner { get; set; }
        public int? numberOnShirt { get; set; }
        public decimal? annualSalary { get; set; }
    }

    public class HealthCheckViewModel
    {
        public int? id { get; set; }
        public DateTime? dateFrom { get; set; }
        public DateTime? dateTo { get; set; }
        public string remark { get; set; }
    }
}
