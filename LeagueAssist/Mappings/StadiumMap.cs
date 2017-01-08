using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class StadiumMap : ClassMap<Stadium>
    {
        public StadiumMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Map(x => x.Capacity);
            Map(x => x.Address);
            References(x => x.City);
            Table("Stadium");
        }
    }
}
