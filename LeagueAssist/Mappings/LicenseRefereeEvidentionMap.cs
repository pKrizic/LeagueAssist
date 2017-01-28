using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings 
{
    class LicenseRefereeEvidentionMap : ClassMap<LicenseRefereeEvidention>
    {
        public LicenseRefereeEvidentionMap()
        {
            Id(x => x.Id);
            References(x => x.referee).Not.LazyLoad();
            References(x => x.season).Not.LazyLoad();
            References(x => x.license).Not.LazyLoad();
            Table("LicenseRefereeEvidention");
        }
    }
}
