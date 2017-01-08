using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Person
    {
        public virtual int Id { get; protected set; }
        public virtual string firstName { get; set; }
        public virtual string lastName { get; set; }
        public virtual DateTime birthDate { get; set; }
        public virtual string Email { get; set; }
        public virtual string Phone { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
    }
}
