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
            References(x => x.Player).Not.LazyLoad();
            Map(x => x.FromDate);
            Map(x => x.ToDate);
            Map(x => x.Remark);
            Table("HealthCheckEvidention");
        }
    }
}
