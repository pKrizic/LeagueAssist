using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;
using FluentNHibernate.Mapping;

namespace LeagueAssist.Mappings
{
    public class PlayerDetailsMap : ClassMap<PlayerDetails>
    {
        public PlayerDetailsMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.BirthDate);
            Map(x => x.Email);
            Map(x => x.Phone);
            Map(x => x.AnnualSalary);
            Map(x => x.ContractId);
            Map(x => x.DateFrom);
            Map(x => x.DateTo);
            Map(x => x.Foreigner);
            Map(x => x.NumberOnShirt);
            Map(x => x.HealthCheckId);
            Map(x => x.FromDate);
            Map(x => x.ToDate);
            Map(x => x.Remark);
        }
    }
}
