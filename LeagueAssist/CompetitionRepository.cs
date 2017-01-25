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
    }
}
