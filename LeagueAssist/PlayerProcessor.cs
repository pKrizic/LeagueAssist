using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public class PlayerProcessor
    {
        private IPlayerRepository _playerRepository;

        public IPlayerRepository Repository
        {
            get { return _playerRepository; }
            set { _playerRepository = value; }
        }

        public PlayerProcessor()
        {
            _playerRepository = new PlayerRepository();
        }

        public PlayerDetails RetrievePlayerDetails(int playerId)
        {
            PlayerDetails result = _playerRepository.GetPlayerDetails(playerId);
            return result;
        }
    }
}
