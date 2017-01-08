using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class HealthCheckEvidention
    {
        public virtual int Id { get; protected set; }
        public virtual Person Player { get; set; }
        public virtual DateTime fromDate { get; set; }
        public virtual DateTime toDate { get; set; }
    }
}
