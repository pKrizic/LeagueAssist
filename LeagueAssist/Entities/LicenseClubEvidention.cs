using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class LicenseClubEvidention
    {
        public virtual int Id { get; protected set; }
        public virtual Organization Organization { get; set; }
        public virtual Season Season { get; set; }
        public virtual License License { get; set; }
        public LicenseClubEvidention() { }
        public LicenseClubEvidention(Organization org, Season s, License l)
        {
            Organization = org;
            Season = s;
            License = l;
        }
    }
}
