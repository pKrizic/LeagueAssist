using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist;
using LeagueAssist.Entities;
namespace LeagueAssist
{
    public interface ILicenseRepository
    {
        List<License> getLicenses();
        void storeClubLicense(LicenseClubEvidention lce);
    }
    public class LicenseRepository : ILicenseRepository
    {
        public List<License> getLicenses()
        {
            var result = new List<License>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<License>)session.QueryOver<License>().List<License>();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void storeClubLicense(LicenseClubEvidention lce)
        {
            var result = lce;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(result);
                    transaction.Commit();
                }
            }
        }
    }
}
