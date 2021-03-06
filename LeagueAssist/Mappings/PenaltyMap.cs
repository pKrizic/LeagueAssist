﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using LeagueAssist.Entities;

namespace LeagueAssist.Mappings
{
    class PenaltyMap : ClassMap<Penalty>
    {
        public PenaltyMap()
        {
            Id(x => x.Id);
            Map(x => x.Type);
            Table("Penalty");
        }
    }
}
