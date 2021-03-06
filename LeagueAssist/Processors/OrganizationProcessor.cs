using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public class OrganizationProcessor
    {
        private IOrganizationRepository _organizationRepository;
        public IOrganizationRepository Repository
        {
            get { return _organizationRepository; }
            set { _organizationRepository = value; }
        }
        public OrganizationProcessor()
        {
            _organizationRepository = new OrganizationRepository();
        }

        public List<Organization> getOrganizations()
        {
            List<Organization> result = _organizationRepository.getOrganizations();
            return result;
        }

        public Organization getOrganization(int id)
        {
            Organization result = _organizationRepository.getOrganization(id);
            return result;
        }

        public List<int> RetrieveOrganizationWithLicence(int seasonId, int competitionId)
        {
            var result = _organizationRepository.GetOrganizationsWithLicence(competitionId, seasonId);
            return result;
        }

        public Stadium RetrieveOrganizationStadium(int organizationId)
        {
            var result = _organizationRepository.GetOrganizationStadium(organizationId);
            return result;
        }

        public void StoreOrganizationChanges(Organization org)
        {
            _organizationRepository.UpdateOrganization(org);
        }

        public void StoreStadiumChanges(Stadium stadium)
        {
            _organizationRepository.UpdateStadium(stadium);
        }
    }
}
