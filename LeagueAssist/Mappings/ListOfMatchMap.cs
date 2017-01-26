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
            Map(x => x.HomeName);
            Map(x => x.FirstOrgScore);
            Map(x => x.SecondOrg_Id);
            Map(x => x.GuestName);
            Map(x => x.SecondOrgScore);
            Map(x => x.fixture_Id);
            Map(x => x.DateTime);
            Table("ListOfMatch");
            ReadOnly();
        }
    }
}
