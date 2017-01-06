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
                    var Srbija = new Country { Name = "Srbija" };

                    var Zagreb = new City { Name = "Zagreb", Country = Hrvatska };

                    session.SaveOrUpdate(Hrvatska);
                    session.SaveOrUpdate(Srbija);
                    session.SaveOrUpdate(Zagreb);

                    transaction.Commit();
                }
            }
        }
    }
}
