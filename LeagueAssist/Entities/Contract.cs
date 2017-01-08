using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Contract
    {
        public virtual int Id { get; protected set; }
        public virtual Person Person { get; set; }
        public virtual DateTime dateFrom { get; set; }
        public virtual DateTime dateTo { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual bool Foreigner { get; set; }
    }
}
