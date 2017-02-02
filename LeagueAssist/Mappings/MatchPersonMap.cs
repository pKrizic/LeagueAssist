using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class MatchPersonMap : ClassMap<MatchPerson>
    {
        public MatchPersonMap()
        {
            Id(x => x.Id);
            References(x => x.Match).Not.LazyLoad();
            References(x => x.Organization).Not.LazyLoad();
            References(x => x.Person).Not.LazyLoad();
            References(x => x.Selection).Not.LazyLoad();
            Map(x => x.Captain);
            Table("MatchPerson");
        }
    }
}
