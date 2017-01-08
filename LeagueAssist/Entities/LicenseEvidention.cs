using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class LicenseEvidention
    {
        public virtual int Id { get; protected set; }
        public virtual Organization Organization { get; set; }
        public virtual Season Season { get; set; }
        public virtual License License { get; set; }
        public virtual Competition Competition { get; set; }
    }
}
