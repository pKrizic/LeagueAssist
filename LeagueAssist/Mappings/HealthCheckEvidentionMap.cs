using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    class HealthCheckEvidentionMap : ClassMap<HealthCheckEvidention>
    {
        public HealthCheckEvidentionMap()
        {
            Id(x => x.Id);
            References(x => x.Player);
            Map(x => x.fromDate);
            Map(x => x.toDate);
            Table("HealthCheckEvidention");
        }
    }
}
