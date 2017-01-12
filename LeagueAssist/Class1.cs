using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class Class1
    {
        public void Store(object zaSpremanje)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(zaSpremanje);
                    
                    var S201516 = new Season { Name = "2015/2016" };
                    var fixture = new Fixture { Name = "1. kolo" };

                    session.SaveOrUpdate(S201516);
                    session.SaveOrUpdate(fixture);

                    transaction.Commit();
                }
            }
        }
        public List<Country> GetAll()
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var allCountries = new List<Country>();
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    allCountries = (List<Country>)session.QueryOver<Country>().List();
                    transaction.Commit();
                }
            }
            return allCountries;
        }

        public string CheckUsernameAndPassword(User user)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var message = "";
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (User)session.QueryOver<User>().Where(u => (u.Password == user.Password) && (u.Username == user.Username)).List().FirstOrDefault();
                    if (result != null)
                        message = result.Id.ToString();
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<PlayerPerformance> GetAllPlayerPerformance()
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var message = new List<PlayerPerformance>();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<PlayerPerformance>)session.QueryOver<PlayerPerformance>().List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }
        
        public List<MatchReferees> GetMatchesForReferee(int id, int numberOfGames)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var message = new List<MatchReferees>();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<MatchReferees>)session.QueryOver<MatchReferees>().Where(u => u.RefereeId == id).OrderBy(u => u.DateTime).Desc.Take(numberOfGames).List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public MatchStadiumInfo GetMatchStadiumInfo(int id)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var message = new MatchStadiumInfo();
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (MatchStadiumInfo)session.QueryOver<MatchStadiumInfo>().Where(u => u.Id == id).List().FirstOrDefault();
                    if (result != null)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<MatchActivityPlayers> GetMatchActivityPlayers(int id)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var message = new List<MatchActivityPlayers>();
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<MatchActivityPlayers>)session.QueryOver<MatchActivityPlayers>().Where(u => u.Id == id).List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();

                }
            }
            return message;
        }

        public List<ListOfPlayers> GetListOfPlayers(int id)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var message = new List<ListOfPlayers>();
            using (var session = sessionFactory.OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    var result = (List<ListOfPlayers>)session.QueryOver<ListOfPlayers>().Where(u => u.Id == id).OrderBy(u => u.OrganizationId).Asc.List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }


        public MatchDetailInfo GetMatchDetailInfo(MatchStadiumInfo stadium, List<MatchActivityPlayers> activities, List<ListOfPlayers> players)
        {
            MatchDetailInfo detail = new MatchDetailInfo();
            detail.HomeFormation = new List<MatchPlayersDetail>();
            detail.AwayFormation = new List<MatchPlayersDetail>();
            detail.Action = new List<PlayerAction>();
            foreach(ListOfPlayers player in players)
            {
                if(player.OrganizationId == stadium.Home)
                {
                    detail.HomeFormation.Add(new MatchPlayersDetail(player.PlayerId, player.FirstName, player.LastName, player.SelectionId, player.Captain, player.NumberOnShirt));
                } else if (player.OrganizationId == stadium.Away)
                {
                    detail.AwayFormation.Add(new MatchPlayersDetail(player.PlayerId, player.FirstName, player.LastName, player.SelectionId, player.Captain, player.NumberOnShirt));
                }
            }
            
            foreach(MatchActivityPlayers activity in activities)
            {
                detail.Action.Add(new PlayerAction(activity.FirstName, activity.LastName, activity.MatchMinute, activity.Description));
            }

            detail.Date = stadium.MatchDate;
            detail.Stadium = stadium.StadiumName;
            detail.City = stadium.CityName;

            return detail;
        }

        public string UpdateMatch(int id, int HomeGoals, int AwayGoals, string Desc, List<MatchActions> lista)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var message = "";
            using(var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (Match)session.QueryOver<Match>().Where(u => u.Id == id).List().FirstOrDefault();
                    result.FirstOrgScore = HomeGoals;
                    result.SecondOrgScore = AwayGoals;
                    result.PostMatchDescription = Desc;
                    List<MatchActivity> mActivites = new List<MatchActivity>();
                    foreach(var item in lista)
                    {
                        var activity = (PlayerPerformance)session.QueryOver<PlayerPerformance>().Where(u => u.Id == item.actionId).List().FirstOrDefault();
                        var player = (Person)session.QueryOver<Person>().Where(u => u.Id == item.playerId).List().FirstOrDefault();
                        var finalMatchActivity = new MatchActivity
                        {
                            Match = result,
                            Player = player,
                            MatchMinute = item.minute,
                            Performance = activity
                        };

                        mActivites.Add(finalMatchActivity);
                    }
                    result.activities = mActivites;
                    session.Update(result);
                    transaction.Commit();

                }
            }

            return message;
        }
    }
}
