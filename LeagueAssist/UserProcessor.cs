using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class UserProcessor
    {
        private IUserRepository _userRepository;

        public IUserRepository Repository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        public UserProcessor()
        {
            _userRepository = new UserRepository();
        }

        public IList<ClubPlayers> GetClubPlayers(int id)
        {
            IList<ClubPlayers> result = _userRepository.GetListOfClubPlayers(id);
            return result;

        }

    }
}
