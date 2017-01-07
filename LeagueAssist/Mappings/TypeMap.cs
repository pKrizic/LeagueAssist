using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class TypeMap : ClassMap<Entities.Type>
    {
        TypeMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            Table("Type");
        }
    }
}
