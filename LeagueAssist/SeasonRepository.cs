using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public interface ISeasonRepository
    {
        List<int> GetIdsOfClubsInCompetition(int competitionId, int seasonId);
        List<Competition> GetCompetititons();
        List<Season> GetSeasons(DateTime date);
        void StoreMatchesFromSeason(Dictionary<int, List<int[]>> dict, int competitionId);
        List<Fixture> GetFixtures();
        List<Match> GetMatchesInOneFixture(int fixtureId);
    }
    public class SeasonRepository : ISeasonRepository
    {
        public List<Fixture> GetFixtures()
        {
            var result = new List<Fixture>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Fixture>)session.QueryOver<Fixture>().List<Fixture>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Match> GetMatchesInOneFixture(int fixtureId)
        {
            var result = new List<Match>();
            var clas = new Class1();
            var session = clas.OpenSession();
            var transaction = session.BeginTransaction();
            result = (List<Match>)session.QueryOver<Match>().Where(m => m.Fixture.Id == fixtureId).List<Match>();
            transaction.Commit();
            return result;
        }

        public List<int> GetIdsOfClubsInCompetition(int competitionId, int seasonId)
        {
            var message = new List<int>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<int>)session.QueryOver<OrgCompetition>().Where(orgC => orgC.Competition.Id == competitionId && orgC.Season.Id == seasonId).Select(OrgC => OrgC.Organization.Id).List<int>();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<Competition> GetCompetititons()
        {
            var message = new List<Competition>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<Competition>)session.QueryOver<Competition>().List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<Season> GetSeasons(DateTime date)
        {
            var message = new List<Season>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<Season>)session.QueryOver<Season>().Where(s => s.StartDay > date).OrderBy(s => s.StartDay).Asc.List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public void StoreMatchesFromSeason(Dictionary<int, List<int[]>> dict, int competitionId)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var competition = session.Get<Competition>(competitionId);
                    foreach (KeyValuePair<int, List<int[]>> schedule in dict)
                    {
                        var round = session.Get<Fixture>(schedule.Key);
                        foreach (var game in schedule.Value)
                        {
                            var firstOrg = session.Get<Organization>(game[0]);
                            var secondOrg = session.Get<Organization>(game[1]);

                            var match = new Match
                            {
                                FirstOrg = firstOrg,
                                SecondOrg = secondOrg,
                                Fixture = round,
                                Competition = competition
                            };
                            session.SaveOrUpdate(match);
                        }
                    }
                    transaction.Commit();
                }
            }
        }
    }
}
