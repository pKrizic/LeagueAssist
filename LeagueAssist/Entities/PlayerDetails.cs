using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class PlayerDetails
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Email { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Phone { get; set; }
        public virtual int ContractId { get; set; }
        public virtual decimal AnnualSalary { get; set; }
        public virtual DateTime DateFrom { get; set; }
        public virtual DateTime DateTo { get; set; }
        public virtual int NumberOnShirt { get; set; }
        public virtual bool Foreigner { get; set; }
        public virtual int HealthCheckId { get; set; }
        public virtual DateTime FromDate { get; set; }
        public virtual DateTime ToDate { get; set; }
        public virtual string Remark { get; set; }
    }
}
