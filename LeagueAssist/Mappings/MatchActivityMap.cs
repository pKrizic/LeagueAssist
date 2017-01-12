using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class MatchActivityMap : ClassMap<MatchActivity>
    {
        public MatchActivityMap()
        {
            Id(x => x.Id);
            References(x => x.Match).Column("Match_Id").Not.Nullable();
            References(x => x.Player);
            References(x => x.Performance);
            Map(x => x.MatchMinute);
            Table("MatchActivity");
        }
    }
}
