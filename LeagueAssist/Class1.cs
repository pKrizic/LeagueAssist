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
                    var Hrvatska = new Country { Name = "Croatia" };
                    var Srbija = new Country { Name = "Srbija" };

                    var Zagreb = new City { Name = "Zagreb", Country = Hrvatska };

                    var S201516 = new Season { Name = "2015/2016" };
                    var fixture = new Fixture { Name = "1. kolo" };

                    session.SaveOrUpdate(Hrvatska);
                    session.SaveOrUpdate(Srbija);
                    session.SaveOrUpdate(Zagreb);

                    

                    session.SaveOrUpdate(S201516);
                    session.SaveOrUpdate(fixture);

                    transaction.Commit();
                }
            }
        }
    }
}
