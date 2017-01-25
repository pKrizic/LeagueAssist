using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class ClubInfoMap : ClassMap<ClubInfo>
    {
        public ClubInfoMap()
        {
            Id(x => x.Id);
            Map(x => x.OrgName);
            Map(x => x.OrgCityName);
            Map(x => x.Address);
            Map(x => x.Capacity);
            Map(x => x.StadiumName);
            Map(x => x.StadiumId);
            Map(x => x.StadiumCityName);
            Table("ClubInfo");
            ReadOnly();
        }
    }
}
