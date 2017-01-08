using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class MatchSubstitutions
    {
        public virtual int Id { get; protected set; }
        public virtual Person PlayerIn { get; set; }
        public virtual Person PlayerOut { get; set; }
        public virtual int MatchMinute { get; set; }


    }
}
