using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist.Entities
{
    public class ListOfPlayers
    {
        public virtual int Id { get; set; }
        public virtual int PlayerId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual int SelectionId { get; set; }
        public virtual bool Captain { get; set; }
        public virtual int OrganizationId { get; set; }
        public virtual int NumberOnShirt { get; set; }
    }
}
