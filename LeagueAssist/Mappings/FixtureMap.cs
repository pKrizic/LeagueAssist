using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class FixtureMap : ClassMap<Fixture>
    {
        public FixtureMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Table("Fixture");
        }
    }
}
