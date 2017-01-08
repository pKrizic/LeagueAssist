using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class OrgStadium
    {
        public virtual int Id { get; protected set; }
        public virtual Organization Organization { get; set; }
        public virtual Stadium Stadium { get; set; }
    }
}
