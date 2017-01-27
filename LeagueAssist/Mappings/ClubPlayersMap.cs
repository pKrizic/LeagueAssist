using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class ClubPlayersMap: ClassMap<ClubPlayers>
    {
        public ClubPlayersMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Organization_Id);
            Map(x => x.DateFrom);
            Map(x => x.DateTo);
        }
    }
}
