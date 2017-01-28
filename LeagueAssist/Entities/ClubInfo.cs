using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class ClubInfo
    {
        public virtual int Id { get; set; }
        public virtual string OrgName { get; set; }
        public virtual string OrgCityName { get; set; }
        public virtual int OrgCityId { get; set; }
        public virtual string Address { get; set; }
        public virtual int Capacity { get; set; }
        public virtual string StadiumName { get; set; }
        public virtual int StadiumId { get; set; }
        public virtual string StadiumCityName { get; set; }
        public virtual int StadiumCityId { get; set; }
        public virtual int UserOrgId { get; set; }
    }
}
