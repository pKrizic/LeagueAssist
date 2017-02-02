using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class CompetitionMap: ClassMap<Competition>
    { 
        public CompetitionMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.ParentOrg);
            Map(x => x.Type);
            Table("Competition");
        }
    }
}
