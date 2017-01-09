using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class MatchStadiumInfoMap: ClassMap<MatchStadiumInfo>
    {
        public MatchStadiumInfoMap()
        {
            Map(x => x.Id);
            Map(x => x.MatchDate);
            Map(x => x.StadiumName);
            Map(x => x.CityName);
            Table("MatchStadiumInfo");
            ReadOnly();
        }
    }
}
