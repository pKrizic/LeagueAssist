using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class License
    {
        public virtual int Id { get; protected set; }
        public virtual string Type { get; set; }
        public virtual Competition Competition { get; set; }
    }
}
