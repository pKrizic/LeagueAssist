using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class ListOfMatchMap : ClassMap<ListOfMatch>
    {
        public ListOfMatchMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstOrg_Id);
            Map(x => x.FirstOrgScore);
            Map(x => x.HomeName);
            Map(x => x.SecondOrg_Id);
            Map(x => x.SecondOrgScore);
            Map(x => x.GuestName);
            Map(x => x.Fixture_Id);
            Map(x => x.FixtureName);
            Map(x => x.Competition_Id);
            Map(x => x.CompetitionName);
            Map(x => x.Type);
            Map(x => x.Season_Id);
            Map(x => x.SeasonName);
            Table("ListOfMatch");
            ReadOnly();
        }
    }
}
