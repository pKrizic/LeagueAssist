﻿using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public interface IMatchRepository
    {
        MatchStadiumInfo GetMatchStadiumInfo(int matchId);
        List<MatchActivityPlayers> GetMatchActivityPlayers(int matchId);
        MatchDetailInfo GetMatchDetailInfo(MatchStadiumInfo stadium, List<MatchActivityPlayers> activities, List<ListOfPlayers> players);
        List<ListOfPlayers> GetListOfPlayers(int matchId);
        List<MatchReferees> GetMatchesForReferee(int refereeId, int numberOfGames);
        List<PlayerPerformance> GetAllPlayerPerformance();
        Match GetMatch(int id);
        List<Match> GetSeasonMatchList(int clubId, int seasonId);
        List<MatchReferees> GetClubMatchs(int idClub, int season, int round, int competition);
        List<MatchPerson> GetPlayersForMatch(int matchId, int orgId);
        List<ListOfMatch> getFullListOfMatch();
        MatchPerson GetPlayerForMatch(int matchId, int orgId, int playerId);
        string UpdateMatch(int id, int HomeGoals, int AwayGoals, string Desc, List<MatchActions> lista);
        void UpdateMatch(Match match);
        void UpdateMatchPerson(MatchPerson matchPerson);
        void DeleteMatchPerson(MatchPerson matchPerson);
        bool GetIsFirstSelection(int selectionId);
    }

    public class MatchRepository : IMatchRepository
    {
        public List<MatchReferees> GetMatchesForReferee(int refereeId, int numberOfGames)
        {
            var message = new List<MatchReferees>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<MatchReferees>)session.QueryOver<MatchReferees>().Where(u => u.RefereeId == refereeId).OrderBy(u => u.DateTime).Desc.Take(numberOfGames).List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public MatchStadiumInfo GetMatchStadiumInfo(int matchId)
        {
            var message = new MatchStadiumInfo();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (MatchStadiumInfo)session.QueryOver<MatchStadiumInfo>().Where(u => u.Id == matchId).List().FirstOrDefault();
                    if (result != null)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }


        public List<MatchActivityPlayers> GetMatchActivityPlayers(int matchId)
        {
            var message = new List<MatchActivityPlayers>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<MatchActivityPlayers>)session.QueryOver<MatchActivityPlayers>().Where(u => u.Id == matchId).List();
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
            foreach (ListOfPlayers player in players)
            {
                if (player.OrganizationId == stadium.Home)
                {
                    detail.HomeFormation.Add(new MatchPlayersDetail(player.PlayerId, player.FirstName, player.LastName, player.SelectionId, player.Captain, player.NumberOnShirt));
                }
                else if (player.OrganizationId == stadium.Away)
                {
                    detail.AwayFormation.Add(new MatchPlayersDetail(player.PlayerId, player.FirstName, player.LastName, player.SelectionId, player.Captain, player.NumberOnShirt));
                }
            }

            foreach (MatchActivityPlayers activity in activities)
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
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (Match)session.QueryOver<Match>().Where(u => u.Id == id).List().FirstOrDefault();
                    result.FirstOrgScore = HomeGoals;
                    result.SecondOrgScore = AwayGoals;
                    result.PostMatchDescription = Desc;
                    List<MatchActivity> mActivites = new List<MatchActivity>();
                    foreach (var item in lista)
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

        public List<PlayerPerformance> GetAllPlayerPerformance()
        {
            var message = new List<PlayerPerformance>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
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
        public List<ListOfPlayers> GetListOfPlayers(int id)
        {
            var message = new List<ListOfPlayers>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<ListOfPlayers>)session.QueryOver<ListOfPlayers>().Where(u => u.Id == id).OrderBy(u => u.OrganizationId).Asc.List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public Match GetMatch(int id)
        {
            var result = new Match();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.Get<Match>(id);
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<Match> GetSeasonMatchList(int clubId, int seasonId)
        {
            var message = new List<Match>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<Match>)session.QueryOver<Match>().Where(u => (u.Season.Id == seasonId) && (u.FirstOrg.Id == clubId || u.SecondOrg.Id == clubId)).List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public void UpdateMatch(Match match)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(match);
                    transaction.Commit();
                }
            }
        }

        public List<MatchReferees> GetClubMatchs(int idClub, int season, int round, int competition)
        {
            var message = new List<MatchReferees>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<MatchReferees>)session.QueryOver<MatchReferees>().Where(u => (u.HomeId == idClub || u.GuestId == idClub) && u.SeasonId == season && u.RoundId == round && u.CompetitionId == competition).List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<MatchPerson> GetPlayersForMatch(int matchId, int orgId)
        {
            var result = new List<MatchPerson>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<MatchPerson>)session.QueryOver<MatchPerson>().Where(u => (u.Match.Id == matchId) && (u.Organization.Id == orgId)).List();
                    transaction.Commit();
                }
            }
            return result;
        }

        public MatchPerson GetPlayerForMatch(int matchId, int orgId, int playerId)
        {
            var result = new MatchPerson();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        result = session.QueryOver<MatchPerson>().Where(u => (u.Match.Id == matchId) && (u.Organization.Id == orgId) && (u.Person.Id == playerId)).List().FirstOrDefault();
                    } catch (Exception e)
                    {
                        
                    }
                    
                    transaction.Commit();
                }
            }
            return result;
        }

        public bool GetIsFirstSelection(int selectionId)
        {
            var result = new Selection();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Selection)session.QueryOver<Selection>().Where(u => (u.Id == selectionId)).List().First();
                    transaction.Commit();
                }
            }
            if (result.Description.ToLower().Equals("U prvoj"))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public List<ListOfMatch> getFullListOfMatch()
        {
            var result = new List<ListOfMatch>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<ListOfMatch>)session.QueryOver<ListOfMatch>().List();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateMatchPerson(MatchPerson matchPerson)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(matchPerson);
                    transaction.Commit();
                }
            }
        }

        public void DeleteMatchPerson(MatchPerson matchPerson)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.Delete(matchPerson);
                    transaction.Commit();
                }
            }
        }
    }
}
