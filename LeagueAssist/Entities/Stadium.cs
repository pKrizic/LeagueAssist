using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class Stadium
    {
        public virtual int Id { get; protected set; }
        public virtual string Name { get; set; }
        public virtual int Capacity { get; set; }
        public virtual string Address { get; set; }
        public virtual City City { get; set; } 

        public Stadium() { }
        
        public Stadium(string Name, int Capacity, string Adress, City City)
        {
            this.Name = Name;
            this.Capacity = Capacity;
            this.Address = Adress;
            this.City = City;
        }
    }
}
