using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class PenaltyEvidention
    {
        public virtual int Id { get; protected set; }
        public virtual Person Player { get; set; }
        public virtual Penalty Penalty { get; set; }
        public virtual DateTime startDate { get; set; }
        public virtual DateTime endDate { get; set; }
        public virtual decimal penaltyValue { get; set; }
    }
}
