using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class SeasonProcessor
    {
        private ISeasonRepository _seasonRepository;

        public ISeasonRepository Repository
        {
            get { return _seasonRepository; }
            set { _seasonRepository = value; }
        }

        public SeasonProcessor()
        {
            _seasonRepository = new SeasonRepository();
        }

        public List<Season> RetrieveSeasons(DateTime date)
        {
            List <Season> result = _seasonRepository.GetSeasons(date);
            return result;
        }

        public List<Season> RetrieveSeasons()
        {
            List<Season> result = _seasonRepository.GetSeasons();
            return result;
        }

        public List<Competition> RetrieveCompetitions()
        {
            List<Competition> result = _seasonRepository.GetCompetititons();
            return result;
        }

        public List<Fixture> RetrieveFixtures()
        {
            List<Fixture> result = _seasonRepository.GetFixtures();
            return result;
        }

        public List<Person> RetrieveReferees()
        {
            List<Person> result = _seasonRepository.GetPersons(1);

            return result;
        }

        public List<Match> RetrieveMatchesInOneFixture(int fixtureId)
        {
            List<Match> result = _seasonRepository.GetMatchesInOneFixture(fixtureId);
            return result;
        }

        public string GenerateTheFixturesForTheSeason (int competitionId, int seasonId)
        {
            bool alreadyCreated = _seasonRepository.MatchesGenerated(competitionId);
            string message = "";
            if (alreadyCreated)
            {
                message = "Već ste kreirali kola za narednu sezonu";
                return message;
            }
            List<int> clubIds = _seasonRepository.GetIdsOfClubsInCompetition(competitionId, seasonId);
            var dict = RoundRobinScheduler(clubIds);
            _seasonRepository.StoreMatchesFromSeason(dict, competitionId, seasonId);
            message = "Kola su uspješno generirana";
            return message;
        }

        private Dictionary<int, List<int[]>> RoundRobinScheduler(List<int> ids)
        {
            Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>();
            List<int[]> listaParova = new List<int[]>();
            if ((ids.Count % 2) == 1)
                ids.Add(0);
            int numberOfRounds = (ids.Count - 1);
            int halfSize = ids.Count / 2;

            List<int> teams = new List<int>();
            teams.AddRange(ids.Skip(halfSize).Take(halfSize));
            teams.AddRange(ids.Skip(1).Take(halfSize - 1).ToArray().Reverse());
            int teamsSize = teams.Count;

            for (int day = 0; day < numberOfRounds; day++)
            {
                dict.Add(day + 1, null);
                int teamIdx = day % teamsSize;
                if ((day % 2) == 1)
                {
                    int[] ekipe = { teams[teamIdx], ids[0] };
                    listaParova.Add(ekipe);
                    for (int idx = 1; idx < halfSize; idx++)
                    {
                        int firstTeam = (day + idx) % teamsSize;
                        int secondTeam = (day + teamsSize - idx) % teamsSize;
                        int[] ekip = { teams[firstTeam], teams[secondTeam] };
                        listaParova.Add(ekip);
                    }
                }
                else
                {
                    int[] ekipe = { ids[0], teams[teamIdx] };
                    listaParova.Add(ekipe);
                    for (int idx = 1; idx < halfSize; idx++)
                    {
                        int firstTeam = (day + teamsSize - idx) % teamsSize;
                        int secondTeam = (day + idx) % teamsSize;
                        int[] ekip = { teams[firstTeam], teams[secondTeam] };
                        listaParova.Add(ekip);
                    }
                }
                dict[day + 1] = listaParova;
                listaParova = new List<int[]>();
            }
            return dict;
        }
    }
}
