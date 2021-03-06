using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public interface IOrganizationRepository
    {
        List<Organization> getOrganizations();
        Organization getOrganization(int id);
        List<int> GetOrganizationsWithLicence(int competitionId, int seasonId);
        Stadium GetOrganizationStadium(int organizationId);
        void UpdateOrganization(Organization org);
        void UpdateStadium(Stadium stadium);
    }
    class OrganizationRepository : IOrganizationRepository
    {
        public List<Organization> getOrganizations()
        {
            var result = new List<Organization>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<Organization>)session.QueryOver<Organization>().List<Organization>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Organization getOrganization(int id)
        {
            var result = new Organization();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Organization)session.QueryOver<Organization>().Where(u => u.Id == id).List().First();
                    transaction.Commit();
                }
            }
            return result;
        }

        public List<int> GetOrganizationsWithLicence(int competitionId, int seasonId)
        {
            var result = new List<int>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<int>)session.QueryOver<ClubLicence>().Where(org => org.CompetitionId == competitionId && org.SeasonId == seasonId).Select(org => org.OrganizationId).List<int>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Stadium GetOrganizationStadium(int organizationId)
        {
            var result = new OrgStadium();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (OrgStadium)session.QueryOver<OrgStadium>().Where(org => org.Organization.Id == organizationId).List().FirstOrDefault();
                    transaction.Commit();
                }
            }
            return result.Stadium;
        }

        public void UpdateOrganization(Organization org)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(org);
                    transaction.Commit();
                }
            }
        }

        public void UpdateStadium(Stadium stadium)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(stadium);
                    transaction.Commit();
                }
            }
        }
    }
}