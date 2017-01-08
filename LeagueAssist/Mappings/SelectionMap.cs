using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class SelectionMap : ClassMap<Selection>
    {
        public SelectionMap()
        {
            Id(x => x.Id);
            Map(x => x.Description);
            Table("Selection");

        }
    }
}
