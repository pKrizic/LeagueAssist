using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Organization
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual User User { get; set; }
        public virtual City City { get; set; }

    }
}
