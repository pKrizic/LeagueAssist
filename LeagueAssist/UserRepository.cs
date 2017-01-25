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
        User GetUserByUsernameAndPassword(string username, string password);
        IList<ClubPlayers> GetListOfClubPlayers(int id);
    }

    public class UserRepository : IUserRepository
    {
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            User result;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = session.QueryOver<User>().Where(u => (u.Password == password) && (u.Username == username)).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result;
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
