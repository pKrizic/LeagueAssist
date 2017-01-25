using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LeagueAssist.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{

    //stvorena za učenje Mock testiranja
    public class DataProcessor
    {
        private IUserRepository _repository;

        public IUserRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        public DataProcessor()
        {
            _repository = new UserRepository();
        }

        public string ProccesData(string username, string password)
        {
            var message = "";
            User user = _repository.GetUserByUsernameAndPassword(username, password);
            if (user != null)
                message = user.Id.ToString();
            return message;
        }
    }

    public class Class1
    {
        private static ISessionFactory _sessionFactory;
       
        public ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                    _sessionFactory = OpenSessionFactory();

                ISession session = _sessionFactory.OpenSession();
                return session;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private ISessionFactory OpenSessionFactory()
        {
            string connectionString = "server=cfd38af2-9264-4bf2-900a-a6e2015e53e3.mysql.sequelizer.com;database=dbcfd38af292644bf2900aa6e2015e53e3;uid=uktzclynyotubsgo;pwd=vpkCLYtAPNS8jx3JtUcQtHQSEBCJBPQvyXgtFwA8etpzRavHNjBpQGpUGz7iuS8a";
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                  .ConnectionString(connectionString).ShowSql().FormatSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Class1>())
                .BuildSessionFactory();
            return _sessionFactory;
        }

        public void Store(object zaSpremanje)
        {
            using (var session = OpenSession())
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

        public List<PlayerPerformance> GetAllPlayerPerformance()
        {
            var message = new List<PlayerPerformance>();
            using (var session = OpenSession())
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
            var message = new List<MatchReferees>();
            using (var session = OpenSession())
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
            var message = new MatchStadiumInfo();
            using (var session = OpenSession())
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
            var message = new List<MatchActivityPlayers>();
            using (var session = OpenSession())
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
            var message = new List<ListOfPlayers>();
            using (var session = OpenSession())
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

        //lista igraca koji pripadaju klubu
        public string GetListOfClubPlayers(int id)
        {
            string message = "";
            using(var session = OpenSession())
            {
                using(var transaction = session.BeginTransaction())
                {
                    Contract c = null;
                    Person p = null;
                    IList<Contract> listaigraca = session.QueryOver<Contract>(() => c)
                                                       .JoinAlias(() => c.Person, () => p)
                                                       .Where(() => p.Id == c.Person.Id)
                                                       .List();

                    message = JsonConvert.SerializeObject(listaigraca);
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
            var message = "";
            using(var session = OpenSession())
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
