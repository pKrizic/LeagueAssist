using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    public class RefereeMap : ClassMap<Referee>
    {
        public  RefereeMap()
        {
            Id(x => x.Id);
            Map(x => x.lastName);
            Map(x => x.firstName);
            Table("Referees");
            ReadOnly();
        }
    }
}
