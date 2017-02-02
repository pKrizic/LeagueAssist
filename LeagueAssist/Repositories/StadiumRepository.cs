using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public interface IStadiumRepository
    {
        //
        List<Stadium> getStadions();
        void storeStadium(Stadium stadium);
    }
    public class StadiumRepository : IStadiumRepository
    { 
        public List<Stadium> getStadions()
        {
            var result = new List<Stadium>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Stadium>)session.QueryOver<Stadium>().List<Stadium>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void storeStadium(Stadium stadium)
        {
            var result = stadium;
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