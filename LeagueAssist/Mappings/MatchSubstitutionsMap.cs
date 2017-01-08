using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    class MatchSubstitutionsMap : ClassMap<MatchSubstitutions>
    {
        public MatchSubstitutionsMap()
        {
            Id(x => x.Id);
            References(x => x.PlayerIn);
            References(x => x.PlayerOut);
            Map(x => x.MatchMinute);
            Table("MatchSubstitutions");
        }
    }
}
