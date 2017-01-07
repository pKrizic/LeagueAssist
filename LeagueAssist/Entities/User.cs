using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class User
    {
        public virtual int Id { get; protected set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual Role Role { get; set; }
    }
}