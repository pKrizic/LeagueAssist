using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class MatchPerson
    {
        public virtual int Id { get; protected set; }
        public virtual Match Match { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Person Person { get; set; }
        public virtual Selection Selection { get; set; }
        public virtual Person Captain { get; set; }
    }
}
