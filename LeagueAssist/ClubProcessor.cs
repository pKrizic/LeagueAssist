using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class ClubProcessor
    {
        private IClubRepository _clubRepository;

        public IClubRepository Repository
        {
            get { return _clubRepository; }
            set { _clubRepository = value; }
        }

        public ClubProcessor()
        {
            _clubRepository = new ClubRepository();
        }

        public ClubInfo GetClubInformation(int id)
        {
            ClubInfo result = _clubRepository.GetClubInfo(id);
            return result;
        }

        public Organization getMyClub(int idUser)
        {
            return _clubRepository.GetOrganizationInfo(idUser);
        }

    }
}
