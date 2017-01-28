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
        List<LicenseClubEvidention> getAllClubLicenses();
        //void storeRefereeEvidention(LicenseRefereeEvidention lre);
        List<LicenseRefereeEvidention> gettAllRefereeLicenses();
    }
    public class LicenseRepository : ILicenseRepository
    {
        public List<LicenseClubEvidention> getAllClubLicenses()
        {
            var result = new List<LicenseClubEvidention>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<LicenseClubEvidention>)session.QueryOver<LicenseClubEvidention>().List();
                    transaction.Commit();
                }
            }
            return result;
        }

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

        public List<LicenseRefereeEvidention> gettAllRefereeLicenses()
        {
            var result = new List<LicenseRefereeEvidention>();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (List<LicenseRefereeEvidention>)session.QueryOver<LicenseRefereeEvidention>().List<LicenseRefereeEvidention>();
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
