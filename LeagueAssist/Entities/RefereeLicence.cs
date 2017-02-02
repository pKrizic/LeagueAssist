using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class RefereeLicence
    {
        public virtual int Id { get; set; }
        public virtual int refereeId { get; set; }
        public virtual int seasonId { get; set; }
        public virtual int competitionId { get; set; }
    }
}
