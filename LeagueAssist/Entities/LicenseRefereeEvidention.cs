using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class LicenseRefereeEvidention
    {
        public virtual int Id { get; set; }
        public virtual Referee referee { get; set; }
        public virtual Season season { get; set; }
        public virtual License license { get; set; }
    }
}
