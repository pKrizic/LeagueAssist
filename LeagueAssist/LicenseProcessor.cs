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
        public List<LicenseRefereeEvidention> LicenseRefereeReturn()
        {
            return Repository.gettAllRefereeLicenses();
        }
    }
}
