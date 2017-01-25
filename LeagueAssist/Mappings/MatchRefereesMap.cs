using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class MatchRefereesMap: ClassMap<MatchReferees> 
    {
        public MatchRefereesMap()
        {
            Id(x => x.Id);
            Map(x => x.RefereeId);
            Map(x => x.HomeName);
            Map(x => x.HomeId);
            Map(x => x.GuestName);
            Map(x => x.GuestId);
            Map(x => x.Round);
            Map(x => x.RoundId);
            Map(x => x.HomeGoals);
            Map(x => x.AwayGoals);
            Map(x => x.CompetitionName);
            Map(x => x.CompetitionId);
            Map(x => x.DateTime);
            Map(x => x.SeasonId);
            Table("MatchReferees");
            ReadOnly();

        }
    }
}
