using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class ContractMap : ClassMap<Contract>
    {
        ContractMap()
        {
            Id(x => x.Id);
            References(x => x.Person);
            Map(x => x.dateFrom);
            Map(x => x.dateTo);
            References(x => x.Organization);
            Map(x => x.Foreigner);
            Table("Contract");
        }
    }
}
