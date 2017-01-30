using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public class LicenseProcessor
    {
        private ILicenseRepository _licenseRepository;
        public ILicenseRepository Repository
        {
            get { return _licenseRepository; }
            set { _licenseRepository = value; }
        }

        public LicenseProcessor(){
            _licenseRepository = new LicenseRepository();            
            }
        public List<License> licenseReturn()
        {
            return Repository.getLicenses();
        }
        public List<LicenseClubEvidention> LicenseClubReturn()
        {
            return Repository.getAllClubLicenses();
        }
        public void startLicenseStore(Organization org, Season s, License l)
        {
            LicenseClubEvidention lce = new LicenseClubEvidention(org, s, l);
            Repository.storeClubLicense(lce);
        }
        public void updateClubLicense(int id, Organization o, Season s, License l)
        {
            LicenseClubEvidention st = Repository.getClubLicense(id);
            st.License = l;
            Repository.updateClubLicense(st);
        }
        public void updateRefereeLicense(int id, Referee o, Season s, License l)
        {
            LicenseRefereeEvidention lre = Repository.getRefereeLicense(id);
            lre.license = l;
            Repository.updateRefereeLicense(lre);
        }
        public LicenseRefereeEvidention GetRefereeInformation(int id)
        {
            LicenseRefereeEvidention result = Repository.getRefereeLicense(id);
            return result;
        }
        public List<LicenseRefereeEvidention> LicenseRefereeReturn()
        {
            return Repository.gettAllRefereeLicenses();
        }

        public void saveRefereeLicense(Referee refer, Season seas, License lic)
        {
            var result = new LicenseRefereeEvidention();
            
            result.referee = refer;
            result.season = seas;
            result.license = lic;

            _licenseRepository.AddRefereeLicense(result);

        }

        public void saveLicence(string name, Competition comp)
        {
            var result = new License();
            result.Type = name;
            result.Competition = comp;

            _licenseRepository.AddLicense(result);
        }

        public List<Referee> RetrieveReferees()
        {
            var result = _licenseRepository.GetAllReferees();
            return result;
        }

        public List<int> RetrieveRefereesWithLicence(int competitionId, int seasonId)
        {
            var result = _licenseRepository.GetRefereesWithLicence(seasonId, competitionId);
            return result;
        }
    }
}
