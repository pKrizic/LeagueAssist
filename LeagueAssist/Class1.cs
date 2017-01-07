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
        public void Store()
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var Hrvatska = new Country {Name = "Croatia" };
                    //var Srbija = new Country { Name = "Srbija" };
                    var Zagreb = new City { Name = "Zagreb", Country = Hrvatska };
                    var zagreb = session.Get<City>(3);
                    var Maksimir = new Stadium { Name = "Maksimir", Capacity = 40000, Address = "Maksimirska 22", City = zagreb };

                    session.SaveOrUpdate(Maksimir);

                    transaction.Commit();
                }
            }
        }
    }
}
