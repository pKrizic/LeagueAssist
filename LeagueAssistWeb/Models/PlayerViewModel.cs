using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeagueAssistWeb.Models
{
    public class PlayerListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class PlayerDetailsViewModel
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime birthDate { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public ContractViewModel contract { get; set; } 
        public HealthCheckViewModel healthCheck { get; set; }
        
    }

    public class ContractViewModel
    {
        public int id { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public bool foreigner { get; set; }
        public int numberOnShirt { get; set; }
        public decimal annualSalary { get; set; }
    }

    public class HealthCheckViewModel
    {
        public int id { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public string remark { get; set; }
    }
}
