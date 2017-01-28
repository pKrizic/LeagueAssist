using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public class CityProcessor
    {
        private ICityRepository _cityRepository;

        public ICityRepository Repository
        {
            get { return _cityRepository; }
            set { _cityRepository = value; }
        }

        public CityProcessor()
        {
            _cityRepository = new CityRepository();
        }

        public List<City> ListOfCity()
        {
            return Repository.getCities();
        }
    }
}