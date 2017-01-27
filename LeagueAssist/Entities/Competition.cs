using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Competition
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual Organization ParentOrg { get; set; }
        public virtual int Type { get; set; }

        public Competition() {
        }
        public Competition(string competitionName, Organization ParentOrg)
        {
            Name = competitionName;
            this.ParentOrg = ParentOrg;
        }
    }
}
