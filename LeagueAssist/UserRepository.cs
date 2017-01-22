using LeagueAssist.Entities;
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
    }
}
