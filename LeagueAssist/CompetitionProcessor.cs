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

        public void PrepareStoreCompetition(String competitionName, Organization Organization)
        {
           
            var result = new Competition(competitionName, Organization);
            _competitionRepository.StoreCompetition(result);

        }
    }
}
