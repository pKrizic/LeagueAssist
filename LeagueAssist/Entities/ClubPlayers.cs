﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class ClubPlayers
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Organization_Id { get; set; }
    }
}
