using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class DeclareMatchDateReferee
    {
        public int Id { get; set; }
        public int RefereeId { get; set; }
        public DateTime Date { get; set; }

        public DeclareMatchDateReferee(int id, int refereeId, DateTime date)
        {
            Id = id;
            RefereeId = refereeId;
            Date = date;
        }
    }
}
