using LeagueAssist.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public interface IClubRepository
    {
        ClubInfo GetClubInfo(int id);
        Organization GetOrganizationInfo(int idUser);
    }

    public class ClubRepository : IClubRepository
    {
        public ClubInfo GetClubInfo(int id)
        {
            ClubInfo message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    message = session.QueryOver<ClubInfo>().Where(u => (u.Id == id)).List().FirstOrDefault();
                    transaction.Commit();

                }
            }
            return message;
        }

        public Organization GetOrganizationInfo(int idUser)
        {
            Organization message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    message = session.QueryOver<Organization>().Where(u => (u.User.Id == idUser)).List().FirstOrDefault();
                    transaction.Commit();

                }
            }
            return message;
        }
    }
}
