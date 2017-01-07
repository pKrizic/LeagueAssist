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

                    var Uloga = new Role { Name = "Gazda" };
                    var Tip = new Entities.Type { Name = "Dobar" };
                    Uloga = (Role)session.Get("Role", 1);

                    var User = new User { Username = "Testko", Password = "123456", Role = Uloga };
                    User = (User)session.Get("User", 2);
                    var Org = new Organization { Name = "Vekton", User = User, City = Zagreb };
                    Org = (Organization)session.Get("Organization", 2);
                    var Persona = new Person { firstName = "Pero", lastName = "Peric", birthDate = DateTime.Now, Email = "a@a.a", Phone = "134678", Type = Tip, User = null };

                    var Contract = new Contract { Person = Persona, dateFrom = DateTime.Now, dateTo = DateTime.Now, Organization = Org, Foreigner = true };

                    session.SaveOrUpdate(Hrvatska);
                    session.SaveOrUpdate(Srbija);
                    session.SaveOrUpdate(Zagreb);
                    session.SaveOrUpdate(Tip);
                    
                    //session.SaveOrUpdate(Uloga);
                    //session.SaveOrUpdate(User);
                    //session.SaveOrUpdate(Org);
                    session.SaveOrUpdate(Persona);
                    session.SaveOrUpdate(Contract);

                    transaction.Commit();
                }
            }
        }
    }
}
