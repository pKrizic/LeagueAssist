using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class ClubLicenceMap : ClassMap<ClubLicence>
    {
        public ClubLicenceMap()
        {
            Id(x => x.Id);
            Map(x => x.CompetitionId);
            Map(x => x.OrganizationId);
            Map(x => x.SeasonId);
            Table("ClubLicence");
            ReadOnly();
        }
    }
}
