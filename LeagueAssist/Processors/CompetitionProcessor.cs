using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeagueAssist
{
    public class CompetitionProcessor
    {
        private ICompetitionRepository _competitionRepository;

        public ICompetitionRepository Repository
        {
            get { return _competitionRepository; }
            set { _competitionRepository = value; }
        }

        public CompetitionProcessor()
        {
            _competitionRepository = new CompetitionRepository();
        }

        public List<Competition> RetrieveCompetitions()
        {
            List<Competition> result = _competitionRepository.GetCompetitions();
            return result;
        }

        public string PrepareStoreCompetition(String competitionName, Organization Organization, RadioButton radio)
        {
            var message = "";
            Competition result;
            if (String.IsNullOrEmpty(competitionName))
                message = "Neka polja nisu popunjena";
            else
            {
                if (radio.Text.Equals("Liga"))
                    result = new Competition(competitionName, Organization, 1);
                else
                    result = new Competition(competitionName, Organization, 0);
                _competitionRepository.StoreCompetition(result);
                message = "Uspješno spremljeno natjecanje";
            }
            return message;
        }

        public string StoreOrganizationsIncompetition(Competition comp, Season season, List<Organization> listOrg)
        {
            if (listOrg.Count == 0)
                return "Niste odabrali niti jedan klub";
            List<OrgCompetition> listOrgComp = new List<OrgCompetition>();
            foreach (var org in listOrg)
                listOrgComp.Add(new OrgCompetition { Organization = org, Competition = comp, Season = season });
            _competitionRepository.AddCompetitionAndClubs(listOrgComp);
            return "Podaci su uspješno spremljeni";
        }

        public string StoreChanges(int id, string name)
        {
            var message = "";
            if (String.IsNullOrEmpty(name))
                message = "Upišite naziv natjecanja.";
            else
            {
                var competition = _competitionRepository.GetCompetition(id);
                competition.Name = name;
                _competitionRepository.UpdateCompetition(competition);
                message = "Podaci su uspješno spremljeni.";
            }
            return message;
        }
    }
}
