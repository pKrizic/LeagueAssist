using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class MatchActivityPlayers
    {
        public virtual int Id { get; set; }
        public virtual int ActivityId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int MatchMinute { get; set; }
        public virtual string Description { get; set; }
        public virtual int PerformanceId { get; set; }

    }
}
