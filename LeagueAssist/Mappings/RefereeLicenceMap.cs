using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class RefereeLicenceMap : ClassMap<RefereeLicence>
    {
        public RefereeLicenceMap()
        {
            Id(x => x.Id);
            Map(x => x.refereeId);
            Map(x => x.seasonId);
            Map(x => x.competitionId);
            Table("RefereeLicence");
            ReadOnly();
        }
    }
}
