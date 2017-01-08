using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Role
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
    }
}
