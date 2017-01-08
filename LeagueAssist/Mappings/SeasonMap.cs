using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class SeasonMap: ClassMap<Season>
    {
        public SeasonMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Table("Season");
        }
    }
}
