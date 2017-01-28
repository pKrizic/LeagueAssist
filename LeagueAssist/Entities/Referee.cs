using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Referee
    {
        public virtual int Id { get; set; }
        public virtual string lastName { get; set; }
        public virtual string firstName { get; set; }
        public override string ToString()
        {
            return lastName+" "+firstName;
        }
    }
}
