﻿using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class ClubProcessor
    {
        private IClubRepository _clubRepository;

        public IClubRepository Repository
        {
            get { return _clubRepository; }
            set { _clubRepository = value; }
        }

        public ClubProcessor()
        {
            _clubRepository = new ClubRepository();
        }

        public ClubInfo GetClubInformation(int id)
        {
            ClubInfo result = _clubRepository.GetClubInfo(id);
            return result;
        }
        public List<Organization> RetrieveAllClubs()
        {
            return _clubRepository.GetAllClubs();
        }

        public Organization getMyClub(int idUser)
        {
            return _clubRepository.GetOrganizationInfo(idUser);
        }

        public List<Stadium> RetrieveAllStadiums()
        {
            List<Stadium> result = _clubRepository.GetAllStadiums();
            return result;
        }

        public List<City> RetrieveAllCities()
        {
            List<City> result = _clubRepository.GetAllCities();
            return result;
        }

        public List<User> RetrieveAllUsers()
        {
            List<User> result = _clubRepository.GetAllUsers();
            return result;
        }

        public string saveClub(string name, Stadium stadium, City city, User user)
        {
            var message = "";
            var result = new Organization();
            var result2 = new OrgStadium();

            if (!String.IsNullOrEmpty(name))
            {
                result.Name = name;
                result.City = city;
                result.User = user;

                result2.Organization = result;
                result2.Stadium = stadium;

                _clubRepository.AddClub(result, result2);
                message = "Podaci su uspješno spremljeni";
            }
            else
                message = "Ime kluba nije uneseno";

            return message;
            
        }

        public void updateClub(int id, string name, Stadium stadium, City city, User user)
        {
            var club = _clubRepository.GetClub(id);
            
            club.Name = name;
            club.City = city;
            club.User = user;

            var orgstad = _clubRepository.GetOrgStadForClub(id);
            orgstad.Stadium = stadium;
            orgstad.Organization = club;
            _clubRepository.UpdateClub(club, orgstad);





        }

        public List<ClubInfo> RetrieveAllClubInfo()
        {
            List<ClubInfo> result = _clubRepository.GetAllClubInfo();
            return result;
        }

        public User RetrieveUser(int id)
        {
            User result = _clubRepository.GetUser(id);
            return result;
        }

    }
}
