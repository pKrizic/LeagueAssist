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
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Id(x => x.Organization_Id);
        }
    }
}
