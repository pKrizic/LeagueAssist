using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Id(x => x.Id);
            References(x => x.Country);
            Map(x => x.Name);
            Table("City");
        }
    }
}
