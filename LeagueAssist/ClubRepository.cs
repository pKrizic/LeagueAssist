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
        List<ClubInfo> getAllClubs();
        List<Organization> GetAllClubs();
    }

    public class ClubRepository : IClubRepository
    {
        public List<Organization> GetAllClubs()
        {
            var message = new List<Organization>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<Organization>)session.QueryOver<Organization>().List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }

            }
            return message;
        }

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

        List<ClubInfo> IClubRepository.getAllClubs()
        {
            throw new NotImplementedException();
        }
    }
}
