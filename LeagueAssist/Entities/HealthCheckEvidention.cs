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
        public virtual DateTime FromDate { get; set; }
        public virtual DateTime ToDate { get; set; }
        public virtual string Remark { get; set; }
    }
}
