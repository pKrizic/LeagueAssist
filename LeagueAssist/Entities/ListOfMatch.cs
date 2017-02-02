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
        public virtual int FirstOrgScore { get; set; }
        public virtual string HomeName { get; set; }
        public virtual int SecondOrg_Id { get; set; }
        public virtual int SecondOrgScore { get; set; }
        public virtual string GuestName { get; set; }
        public virtual int Fixture_Id { get; set; }
        public virtual string FixtureName { get; set; }
        public virtual int Competition_Id { get; set; }
        public virtual string CompetitionName { get; set; }
        public virtual int Type { get; set; }
        public virtual int Season_Id { get; set; }
        public virtual string SeasonName { get; set; }
    }   
}