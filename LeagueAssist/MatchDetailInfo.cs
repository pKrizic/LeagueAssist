using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LeagueAssist
{
    public class MatchDetailInfo
    {
        public List<MatchPlayersDetail> HomeFormation { get; set; }
        public List<MatchPlayersDetail> AwayFormation { get; set; }
        public List<PlayerAction> Action { get; set; }
        public DateTime Date { get; set; }
        public string Stadium { get; set; }
        public string City { get; set; }

    }

    public class MatchPlayersDetail
    {
        public MatchPlayersDetail (int id,string i, string p, int up, bool cpt)
        {
            this.id = id;
            this.ime = i;
            this.prezime = p;
            this.uPrvoj = up;
            this.kapetan = cpt;
        }
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public int uPrvoj { get; set; }
        public bool kapetan { get; set; }
    }

    public class PlayerAction
    {
        public PlayerAction(string i, string p, int min, string akc)
        {
            this.ime = i;
            this.prezime = p;
            this.minuta = min;
            this.akcija = akc;
        }
        public string ime { get; set; }
        public string prezime { get; set; }
        public int minuta { get; set; }
        public string akcija { get; set; }
        
    }
}