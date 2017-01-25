using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class MatchProcessor
    {
        private IMatchRepository _matchRepository;

        public IMatchRepository Repository
        {
            get { return _matchRepository; }
            set { _matchRepository = value; }
        }

        public MatchProcessor()
        {
            _matchRepository = new MatchRepository();
        }


        public List<MatchReferees> RetrieveMatchesforReferee(int refereeId, int numberOfGamaes)
        {
            List < MatchReferees > result = _matchRepository.GetMatchesForReferee(refereeId, numberOfGamaes);
            return result;
        }

        public MatchDetailInfo RetrieveMatchDetails (int matchId)
        {
            var stadium = _matchRepository.GetMatchStadiumInfo(matchId);
            var matchActivity = _matchRepository.GetMatchActivityPlayers(matchId);
            var playerList = _matchRepository.GetListOfPlayers(matchId);

            MatchDetailInfo result = _matchRepository.GetMatchDetailInfo(stadium, matchActivity, playerList);
            return result;
        }

        public string UpdateMatchInfo(int id, int HomeGoals, int AwayGoals, string Desc, List<MatchActions> lista)
        {
            string result = _matchRepository.UpdateMatch(id, HomeGoals, AwayGoals, Desc, lista);
            return result;
        }

        public List<PlayerPerformance> GetPlayerPerformance()
        {
            List<PlayerPerformance> result = GetPlayerPerformance();
            return result;

        }

        public List<MatchReferees> GetListClubMatchs(int idClub, int season, int round, int competition)
        {
            List<MatchReferees> match = _matchRepository.GetClubMatchs(idClub, season, round, competition);
            return match;
        }

    }
}
