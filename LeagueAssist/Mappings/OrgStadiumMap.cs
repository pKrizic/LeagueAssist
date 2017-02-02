using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class OrgStadiumMap : ClassMap<OrgStadium>
    {
        public OrgStadiumMap()
        {
            Id(x => x.Id);
            References(x => x.Organization).Not.LazyLoad();
            References(x => x.Stadium).Not.LazyLoad();
            Table("OrgStadium");
        }
    }
}
