﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Season
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual DateTime StartDay { get; set; }
    }
}
