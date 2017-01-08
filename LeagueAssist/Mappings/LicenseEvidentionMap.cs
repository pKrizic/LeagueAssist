using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    class LicenseEvidentionMap : ClassMap<LicenseEvidention>
    {
        public LicenseEvidentionMap()
        {
            Id(x => x.Id);
            References(x => x.Club);
            References(x => x.Season);
            References(x => x.License);
            References(x => x.Competition);
            Table("LicenseEvidention");
        }
    }
}
