using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string PrepareStoreCompetition(String competitionName, Organization Organization)
        {
            var message = "";
            if (String.IsNullOrEmpty(competitionName))
                message = "Neka polja nisu popunjena";
            else
            {
                var result = new Competition(competitionName, Organization);
                _competitionRepository.StoreCompetition(result);
                message = "Uspješno spremljeno natjecanje";
            }
            return message;
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
