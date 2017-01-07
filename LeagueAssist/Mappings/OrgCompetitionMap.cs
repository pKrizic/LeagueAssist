using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class OrgCompetitionMap : ClassMap<OrgCompetition>
    {
        public OrgCompetitionMap()
        {
            Id(x => x.Id);
            References(x => x.Organization);
            References(x => x.Competition);
            References(x => x.Season);
            Table("OrgCompetition");
        }
    }
}
