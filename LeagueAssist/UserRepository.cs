using LeagueAssist.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public interface IUserRepository
    {
        User GetUserByUsernameAndPassword(string username, string password, int roleId);
        IList<ClubPlayers> GetListOfClubPlayers(int id);
        Person GetPerson(int id);
        void SaveUpdatePerson(Person person);
        List<User> GetUsers();
        Entities.Type GetType(int id);
    }

    public class UserRepository : IUserRepository
    {
        public User GetUserByUsernameAndPassword(string username, string password, int roleId)
        {
            User result;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<User>().Where(u => (u.Password == password) && (u.Username == username) && (u.Role.Id == roleId)).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<User> GetUsers()
        {
            var result = new List<User>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<User>)session.QueryOver<User>().List() ;
                    transaction.Commit();
                }
            }
            return result;
        }

        public Person GetPerson(int id)
        {
            Person result = new Person();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.Get<Person>(id);
                    transaction.Commit();
                }
            }
            return result;
        }

        public Entities.Type GetType(int id)
        {
            var result = new Entities.Type();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.Get<Entities.Type>(id);
                    transaction.Commit();
                }
            }
            return result;

        }

        public void SaveUpdatePerson(Person person)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(person);
                    transaction.Commit();
                }
            }
        }

        //lista igraca koji pripadaju klubu
        public IList<ClubPlayers> GetListOfClubPlayers(int id)
        {
            IList<ClubPlayers> message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    message = session.QueryOver<ClubPlayers>().Where(u => (u.Organization_Id == id)).List();
                    transaction.Commit();

                }
            }
            return message;
        }
    }
}
