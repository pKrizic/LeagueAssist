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
        private IUserRepository _userRepository;

        public IMatchRepository Repository
        {
            get { return _matchRepository; }
            set { _matchRepository = value; }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        public MatchProcessor()
        {
            _matchRepository = new MatchRepository();
            _userRepository = new UserRepository();
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

        public Match RetrieveMatch (int matchId)
        {
            var result = _matchRepository.GetMatch(matchId);
            return result;
        }

        public List<Match> RetrieveSeasonMatchList (int clubId, int seasonId)
        {
            List<Match> result = _matchRepository.GetSeasonMatchList(clubId, seasonId);
            return result;
        }

        public string UpdateMatchInfo(int id, int HomeGoals, int AwayGoals, string Desc, List<MatchActions> lista)
        {
            string result = _matchRepository.UpdateMatch(id, HomeGoals, AwayGoals, Desc, lista);
            return result;
        }

        public List<PlayerPerformance> GetPlayerPerformance()
        {
            List<PlayerPerformance> result =  _matchRepository.GetAllPlayerPerformance();
            return result;
        }

        public void SetMatchreferee(int id, int refereeId)
        {
            Match match = _matchRepository.GetMatch(id);
            Person referee = _userRepository.GetPerson(refereeId);
            match.Referee = referee;
            _matchRepository.UpdateMatch(match);
        }

        public List<MatchReferees> GetListClubMatchs(int idClub, int season, int round, int competition)
        {
            List<MatchReferees> match = _matchRepository.GetClubMatchs(idClub, season, round, competition);
            return match;
        }

        public List<MatchPerson> RetrievePlayersForMatch(int matchId, int orgId)
        {
            List<MatchPerson> players = _matchRepository.GetPlayersForMatch(matchId, orgId);
            return players;
        }

        public bool RetrieveIsFirstSelection(int selectionId)
        {
            bool result = _matchRepository.GetIsFirstSelection(selectionId);
            return result;
        }

    }
}
