using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public interface IPlayerRepository
    {
        PlayerDetails GetPlayerDetails(int playerId);
    }
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerDetails GetPlayerDetails(int playerId)
        {
            var result = new PlayerDetails();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (PlayerDetails)session.QueryOver<PlayerDetails>().Where(x => x.Id == playerId).OrderBy(x => x.DateTo).Desc.List().First();
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
