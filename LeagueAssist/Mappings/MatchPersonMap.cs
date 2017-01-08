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
            References(x => x.Match);
            References(x => x.Organization);
            References(x => x.Person);
            References(x => x.Selection);
            References(x => x.Captain);
            Table("MatchPerson");
        }
    }
}
