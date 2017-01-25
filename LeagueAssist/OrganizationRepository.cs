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
    }
}