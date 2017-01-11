﻿using FluentNHibernate.Mapping;
using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Mappings
{
    public class MatchActivityPlayersMap: ClassMap<MatchActivityPlayers>
    {
        public MatchActivityPlayersMap()
        {
            Id(x => x.Id);
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.MatchMinute);
            Map(x => x.Description);
            Map(x => x.PerformanceId);
            Table("MatchActivityPlayers");
            ReadOnly();
        }
    }
}