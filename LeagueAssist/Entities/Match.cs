using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Match
    {
        public virtual int Id { get; protected set; }
        public virtual Organization FirstOrg { get; set; }
        public virtual Organization SecondOrg { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual Fixture Fixture { get; set; }
        public virtual Person Referee { get; set; }
        public virtual DateTime DateTime { get; set; }
        public virtual int FirstOrgScore { get; set; }
        public virtual int SecondOrgScore { get; set; }
        public virtual string PostMatchDescription { get; set; }
        public virtual IList<MatchActivity> activities { get; set; }

    }
}
