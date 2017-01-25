﻿using LeagueAssist.Entities;
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

        public string ProccesData(string username, string password)
        {
            var message = "";
            User user = _repository.GetUserByUsernameAndPassword(username, password);
            if (user != null)
                message = user.Id.ToString();
            return message;
        }

        public Person GetPerson(int id)
        {
            Person referee = _repository.GetPerson(id);
            return referee;
        }

        public void SaveUpdatePerson(int id, string ime, string prezime, string date, string email, string telefon, User user)
        {
            var person = new Person();
            if (id != 0)
                person = _repository.GetPerson(id);

            person.Type = _repository.GetType(1);
            person.FirstName = ime;
            person.LastName = prezime;
            person.BirthDate = Convert.ToDateTime(date);
            person.Email = email;
            person.Phone = telefon;
            person.User = user;

            _repository.SaveUpdatePerson(person);
        }
    }
}
