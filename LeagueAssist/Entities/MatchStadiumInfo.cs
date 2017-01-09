using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class MatchStadiumInfo
    {
        public virtual int Id { get; set; }
        public virtual DateTime MatchDate { get; set; }
        public virtual string StadiumName { get; set; }
        public virtual string CityName { get; set; }
    }
}
