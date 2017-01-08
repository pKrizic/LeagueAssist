using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
   public class MatchActivity
    {
        public virtual int Id { get; protected set; }
        public virtual Match Match { get; set; }
        public virtual Person Player { get; set; }
        public virtual PlayerPerformance Performance { get; set; }
        public virtual int MatchMinute { get; set; }

    }
}
