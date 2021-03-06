using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{   
    public interface ICityRepository
    {
        List<City> getCities();
        City getCity(int id);
    }

    public class CityRepository : ICityRepository
    {
        public List<City> getCities()
        {
            var result = new List<City>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<City>)session.QueryOver<City>().List<City>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public City getCity(int id)
        {
            var result = new City();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<City>().Where(x => x.Id == id).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }
    }
}
