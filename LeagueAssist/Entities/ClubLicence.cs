using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class ClubLicence
    {
        public virtual int Id { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual int SeasonId { get; set; }
        public virtual int CompetitionId { get; set; }
    }
}
