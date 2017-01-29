using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    //stvorena za učenje Mock testiranja
    public class DataProcessor
    {
        private IUserRepository _repository;

        public IUserRepository Repository
        {
            get { return _repository; }
            set { _repository = value; }
        }

        public DataProcessor()
        {
            _repository = new UserRepository();
        }

        public string ProccesData(string username, string password, int roleId)
        {
            var message = "";
            User user = _repository.GetUserByUsernameAndPassword(username, password, roleId);
            Person person = _repository.GetPersonFromUserId(user.Id);
            if (user != null)
                message = person.Id.ToString();
            return message;
        }

        public Person GetPerson(int id)
        {
            Person referee = _repository.GetPerson(id);
            return referee;
        }

        public string SaveUpdatePerson(int id, string ime, string prezime, string date, string email, string telefon, User user)
        {
            var person = new Person();
            var message = "";
            if (id != 0)
                person = _repository.GetPerson(id);

            if (String.IsNullOrEmpty(ime) || String.IsNullOrEmpty(prezime) || String.IsNullOrEmpty(date) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(telefon))
                message = "Nisu popunjena sva polja, popunite polja pa pokušajte ponovo";
            else
            {
                person.Type = _repository.GetType(1);
                person.FirstName = ime;
                person.LastName = prezime;
                person.BirthDate = Convert.ToDateTime(date);
                person.Email = email;
                person.Phone = telefon;
                person.User = user;

                _repository.SaveUpdatePerson(person);
                message = "Podaci su uspješno spremljeni";
            }
            return message;
        }
    }



    public class UserProcessor
    {
        private IUserRepository _userRepository;

        public IUserRepository Repository
        {
            get { return _userRepository; }
            set { _userRepository = value; }
        }

        public UserProcessor()
        {
            _userRepository = new UserRepository();
        }

        public IList<ClubPlayers> GetClubPlayers(int id)
        {
            IList<ClubPlayers> result = _userRepository.GetListOfClubPlayers(id);
            return result;

        }

    }
}
