using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class MatchMap : ClassMap<Match>
    {
        public MatchMap()
        {
            Id(x => x.Id);
            References(x => x.FirstOrg).Not.LazyLoad();
            References(x => x.SecondOrg).Not.LazyLoad();
            References(x => x.Competition);
            References(x => x.Fixture);
            References(x => x.Referee);
            References(x => x.Season).Not.LazyLoad();
            Map(x => x.DateTime);
            Map(x => x.FirstOrgScore);
            Map(x => x.SecondOrgScore);
            Map(x => x.PostMatchDescription);
            HasMany(x => x.activities).Inverse().KeyColumn("Match_Id").Cascade.All();
            Table("Match2");
        }
    }
}
