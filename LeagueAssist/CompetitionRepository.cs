using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public interface ICompetitionRepository
    {
        List<Competition> GetCompetitions();
        void StoreCompetition(Competition competition);
        void UpdateCompetition(Competition competition);
        Competition GetCompetition(int id);
    }
    public class CompetitionRepository : ICompetitionRepository
    {
        public List<Competition> GetCompetitions()
        {
            var result = new List<Competition>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Competition>)session.QueryOver<Competition>().List<Competition>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdateCompetition(Competition competition)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(competition);
                    transaction.Commit();
                }
            }
        }

        public Competition GetCompetition(int id)
        {
            var result = new Competition();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.Get<Competition>(id);
                }
            }
            return result;
        }

        public void StoreCompetition(Competition competition)
        {
            var result = competition;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(result);
                    transaction.Commit();
                }
            }
        }
    }
}
