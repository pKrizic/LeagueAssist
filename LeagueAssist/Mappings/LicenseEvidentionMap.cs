using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    class LicenseClubEvidentionMap : ClassMap<LicenseClubEvidention>
    {
        public LicenseClubEvidentionMap()
        {
            Id(x => x.Id);
            References(x => x.Organization);
            References(x => x.Season);
            References(x => x.License);
            Table("LicenseClubEvidention");
        }
    }
}
