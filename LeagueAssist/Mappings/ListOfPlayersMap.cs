using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class ListOfPlayersMap: ClassMap<ListOfPlayers>
    {
        public ListOfPlayersMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.SelectionId);
            Map(x => x.Captain);
            Map(x => x.OrganizationId);
            Table("ListOfPlayers");
            ReadOnly();

        }
    }
}
