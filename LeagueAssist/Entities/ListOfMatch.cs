using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class ListOfMatch
    {
        public virtual int Id { get; set; }
        public virtual int FirstOrg_Id { get; set; }
        public virtual string HomeName { get; set; }
        public virtual int FirstOrgScore { get; set; }
        public virtual int SecondOrg_Id { get; set; }
        public virtual string GuestName { get; set; }
        public virtual int SecondOrgScore { get; set; }
        public virtual int fixture_Id { get; set; }
        public virtual DateTime DateTime { get; set; }
    }
    
}
}
