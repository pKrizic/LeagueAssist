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
        List<Organization> GetAllClubs();
        List<Stadium> GetAllStadiums();
        List<City> GetAllCities();
        List<User> GetAllUsers();
        void AddClub(Organization org, OrgStadium stadium);
        List<ClubInfo> GetAllClubInfo();
        User GetUser(int id);
        Organization GetClub(int id);
        OrgStadium GetOrgStadForClub(int id);
        void UpdateClub(Organization org, OrgStadium stadium);
        List<Organization> GetAllClubs();
        Organization GetOrganizationInfo(int idUser);
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

       

        public List<Stadium> GetAllStadiums()
        {
            var message = new List<Stadium>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<Stadium>)session.QueryOver<Stadium>().List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<City> GetAllCities()
        {
            var message = new List<City>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<City>)session.QueryOver<City>().List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public List<User> GetAllUsers()
        {
            var message = new List<User>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<User>)session.QueryOver<User>().List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public void AddClub(Organization org, OrgStadium stadium)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(org);
                    session.SaveOrUpdate(stadium);
                    transaction.Commit();
                }
            }
        }

        public void UpdateClub(Organization org, OrgStadium stadium)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(org);
                    session.SaveOrUpdate(stadium);
                    transaction.Commit();
                }
            }
        }

        public List<ClubInfo> GetAllClubInfo()
        {
            var message = new List<ClubInfo>();
            var clas = new Class1();
            
            using(var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<ClubInfo>)session.QueryOver<ClubInfo>().List();
                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public User GetUser(int id)
        {
            User message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (User)session.QueryOver<User>().Where(u => u.Id == id).List().FirstOrDefault();
                    if (result != null)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public Organization GetClub(int id)
        {
            Organization message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (Organization)session.QueryOver<Organization>().Where(u => u.Id == id).List().FirstOrDefault();
                    if (result != null)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

        public OrgStadium GetOrgStadForClub(int id)
        {
            OrgStadium message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (OrgStadium)session.QueryOver<OrgStadium>().JoinQueryOver(x => x.Organization).Where(u => u.Id == id ).List().FirstOrDefault();
                    // var result = (OrgStadium)session.QueryOver<OrgStadium>().Where(u => u.Organization == club).List().FirstOrDefault();
                    if (result != null)
                        message = result;
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
