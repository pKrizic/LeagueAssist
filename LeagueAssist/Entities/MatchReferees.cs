using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class MatchReferees
    {
        public virtual int Id { get; set; }
        public virtual int RefereeId { get; set; }
        public virtual string HomeName { get; set; }
        public virtual string GuestName { get; set; }
        public virtual string Round { get; set; }
        public virtual int HomeGoals { get; set; }
        public virtual int GuestGoals { get; set; }
    }
}
