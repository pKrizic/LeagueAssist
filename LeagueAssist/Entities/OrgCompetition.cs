using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class OrgCompetition
    {
        public virtual int Id { get; protected set; }
        public virtual Organization Organization { get; set; }
        public virtual Competition Competition { get; set; }
        public virtual Season Season { get; set; }

        //public OrgCompetition(Organization org, Competition comp, Season season)
        //{
        //    this.Organization = org;
        //    this.Competition = comp;
        //    this.Season = season;
        //}
    }
}
