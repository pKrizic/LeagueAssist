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
        LicenseClubEvidention getClubLicense(int id);
        void updateClubLicense(LicenseClubEvidention lce);
        LicenseRefereeEvidention getRefereeLicense(int id);
        void updateRefereeLicense(LicenseRefereeEvidention lre);
        void AddRefereeLicense(LicenseRefereeEvidention refLic);
        void AddLicense(License licenca);
        List<Referee> GetAllReferees();
    }
    public class LicenseRepository : ILicenseRepository
    {
        private string id;

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

        public LicenseClubEvidention getClubLicense(int id)
        {
            LicenseClubEvidention message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (LicenseClubEvidention)session.QueryOver<LicenseClubEvidention>().Where(u => u.Id == id).List().FirstOrDefault();
                    if (result != null)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
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

        public LicenseRefereeEvidention getRefereeLicense(int id)
        {
            LicenseRefereeEvidention message = null;
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (LicenseRefereeEvidention)session.QueryOver<LicenseRefereeEvidention>().Where(u => u.Id == id).List().FirstOrDefault();
                    if (result != null)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
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

        public void updateClubLicense(LicenseClubEvidention lce)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(lce);
                    transaction.Commit();
                }
            }
        }

        public void updateRefereeLicense(LicenseRefereeEvidention lre)
        {
            var result = lre;
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

        public void AddRefereeLicense(LicenseRefereeEvidention refLic)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(refLic);
                    transaction.Commit();
                }
            }
        }

        public void AddLicense(License licenca)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(licenca);
                    transaction.Commit();
                }
            }
        }

        public List<Referee> GetAllReferees()
        {
            var message = new List<Referee>();
            var clas = new Class1();
            using(var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    var result = (List<Referee>)session.QueryOver<Referee>().List<Referee>();

                    if (result != null && result.Count > 0)
                        message = result;
                    transaction.Commit();
                }
            }
            return message;
        }

    }
}
