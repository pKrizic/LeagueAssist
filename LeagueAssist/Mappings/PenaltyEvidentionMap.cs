using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    class PenaltyEvidentionMap : ClassMap<PenaltyEvidention>
    {
        public PenaltyEvidentionMap()
        {
            Id(x => x.Id);
            References(x => x.Penalty);
            References(x => x.Player);
            Map(x => x.startDate);
            Map(x => x.endDate);
            Map(x => x.penaltyValue);
            Table("PenaltyEvidention");
        }
    }
}
