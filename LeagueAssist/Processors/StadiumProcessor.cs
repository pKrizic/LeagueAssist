using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
   public class StadiumProcessor
    {
        private IStadiumRepository _stadiumRepository;
        public IStadiumRepository Repository
        {
            get { return _stadiumRepository; }
            set { _stadiumRepository = value; }
        }

        public StadiumProcessor()
        {
            _stadiumRepository = new StadiumRepository();
        }
        public void prepareStoreStadium(string Name, int Capacity, string Adress, City City)
        {
            var result = new Stadium(Name, Capacity, Adress, City);
            _stadiumRepository.storeStadium(result);
        }
    }
}
