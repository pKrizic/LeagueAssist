using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LeagueAssist;
using Moq;
using LeagueAssist.Entities;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        //Unit testovi
        [TestMethod]
        public void PrviTest()
        {
            //arrange
            //očekivana vrijednost, definicija parametara

            //act
            //poziv funkcije

            //assert
            //usporedba rezultata sa ocekivanim Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly"); 
        }

        [TestMethod]
        public void DeclareMatchDateReferee_Test()
        {
            int id = 1;
            int refereeId = 2;
            DateTime date = DateTime.Now;

            var match = new DeclareMatchDateReferee(id, refereeId, date);

            Assert.AreEqual(id, match.Id, "Wrong Id");
            Assert.AreEqual(refereeId, match.RefereeId, "Wrong refereeID");
            Assert.AreEqual(date, match.Date, "Wrong date");
        }

        [TestMethod]
        public void Stadium_Test()
        {
            string name = "Maksimir";
            int capacity = 10000;
            string addres = "Selska";
            var city = new City();

            var stadium = new Stadium(name, capacity, addres, city);

            Assert.AreEqual(name, stadium.Name, "Wrong name");
            Assert.AreEqual(capacity, stadium.Capacity, "Wrong capacity");
            Assert.AreEqual(addres, stadium.Address, "Wrong address");
            Assert.AreEqual(city, stadium.City, "Wrong city");
        }

        //Mocking testovi
        [TestMethod]
        public void Validate_Login()
        {
            string username = "i";
            string password = "i";
            int userId = 3;
            //postavljamo useru atribute jer će nam trebati prilikom poziva druge funkcije
            User user = new User{ Id = 3, Password = "i", Username = "i"};
            Person person = new Person();

            var repository = new Mock<IUserRepository>();
            repository.Setup(x => x.GetUserByUsernameAndPassword(username, password, 1)).Returns(user);
            repository.Setup(x => x.GetPersonFromUserId(userId)).Returns(person);

            DataProcessor processor = new DataProcessor();
            processor.Repository = (IUserRepository)repository.Object;

            var res = processor.ProccesData(username, password, 1);

            repository.Verify(x => x.GetUserByUsernameAndPassword(username, password, 1), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_SaveUpdatePerson()
        {
            string firstName = "Testkgfhfo";
            string lastName = "123456";
            string date = "12.04.1933.";
            string email = "fdsfds@dfs";
            int id = 1;
            string phone = "0239393";
            User user = new User();
            var person = new Person();

            var repository = new Mock<IUserRepository>();
            repository.Setup(x => x.GetPerson(id)).Returns(person);
            repository.Setup(x => x.SaveUpdatePerson(person));
            repository.Setup(x => x.GetType(id));

            DataProcessor processor = new DataProcessor();
            processor.Repository = (IUserRepository)repository.Object;

            var res = processor.SaveUpdatePerson(id, firstName, lastName, date, email, phone, user);

            repository.Verify(x => x.GetPerson(id), Times.Exactly(1));
            repository.Verify(x => x.GetType(id), Times.Exactly(1));
            repository.Verify(x => x.SaveUpdatePerson(person), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_GetOrganisation()
        {
            int id = 1;
            var organization = new Organization();

            var repository = new Mock<IOrganizationRepository>();
            repository.Setup(x => x.getOrganization(id)).Returns(organization);

            OrganizationProcessor processor = new OrganizationProcessor();
            processor.Repository = (IOrganizationRepository)repository.Object;

            var res = processor.getOrganization(id);

            repository.Verify(x => x.getOrganization(id), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_GetOrganisations()
        {
            var organizations = new List<Organization>();

            var repository = new Mock<IOrganizationRepository>();
            repository.Setup(x => x.getOrganizations()).Returns(organizations);

            OrganizationProcessor processor = new OrganizationProcessor();
            processor.Repository = (IOrganizationRepository)repository.Object;

            var res = processor.getOrganizations();

            repository.Verify(x => x.getOrganizations(), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_ListOfCity()
        {
            var cities = new List<City>();

            var repository = new Mock<ICityRepository>();
            repository.Setup(x => x.getCities()).Returns(cities);

            CityProcessor processor = new CityProcessor();
            processor.Repository = (ICityRepository)repository.Object;

            var res = processor.ListOfCity();

            repository.Verify(x => x.getCities(), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_StoreChanges()
        {
            string competitionName = "Prva Hrvatska Liga";
            int id = 1;
            Competition comp = new Competition();

            var repository = new Mock<ICompetitionRepository>();
            repository.Setup(x => x.GetCompetition(id)).Returns(comp);
            repository.Setup(x => x.UpdateCompetition(comp));

            CompetitionProcessor processor = new CompetitionProcessor();
            processor.Repository = (ICompetitionRepository)repository.Object;

            var res = processor.StoreChanges(id, competitionName);

            repository.Verify(x => x.GetCompetition(id), Times.Exactly(1));
            repository.Verify(x => x.UpdateCompetition(comp), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_RetrieveMatchDetail()
        {
            int id = 1;
            MatchStadiumInfo stadium = new MatchStadiumInfo();
            List<MatchActivityPlayers> ma = new List<MatchActivityPlayers>();
            List<ListOfPlayers> list = new List<ListOfPlayers>();

            var repository = new Mock<IMatchRepository>();
            repository.Setup(x => x.GetMatchStadiumInfo(id)).Returns(stadium);
            repository.Setup(x => x.GetMatchActivityPlayers(id)).Returns(ma);
            repository.Setup(x => x.GetListOfPlayers(id)).Returns(list);

            MatchProcessor processor = new MatchProcessor();
            processor.Repository = (IMatchRepository)repository.Object;

            var res = processor.RetrieveMatchDetails(id);

            repository.Verify(x => x.GetMatchStadiumInfo(id), Times.Exactly(1));
            repository.Verify(x => x.GetMatchActivityPlayers(id), Times.Exactly(1));
            repository.Verify(x => x.GetListOfPlayers(id), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_SetMatchreferee()
        {
            int id = 1;
            int refereeId = 1;
            LeagueAssist.Entities.Match match = new LeagueAssist.Entities.Match();
            Person referee = new Person();

            var matchRepository = new Mock<IMatchRepository>();
            var userRepository = new Mock<IUserRepository>();
            matchRepository.Setup(x => x.GetMatch(id)).Returns(match);
            matchRepository.Setup(x => x.UpdateMatch(match));
            userRepository.Setup(x => x.GetPerson(refereeId)).Returns(referee);

            MatchProcessor processor = new MatchProcessor();
            processor.Repository = (IMatchRepository)matchRepository.Object;
            processor.UserRepository = (IUserRepository)userRepository.Object;

            processor.SetMatchreferee(id, refereeId);

            matchRepository.Verify(x => x.GetMatch(id), Times.Exactly(1));
            //ako odkomentiramo liniju test ne prolazi
            //matchRepository.Verify(x => x.GetMatchActivityPlayers(id), Times.Exactly(1)); 
            userRepository.Verify(x => x.GetPerson(refereeId), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_RetrieveHealthCheck()
        {
            int id = 1;
            HealthCheckEvidention health = new HealthCheckEvidention();

            var repository = new Mock<IPlayerRepository>();
            repository.Setup(x => x.GetHealthCheck(id)).Returns(health);

            PlayerProcessor processor = new PlayerProcessor();
            processor.Repository = (IPlayerRepository)repository.Object;

            var res = processor.RetrieveHealthCheck(id);
            repository.Verify(x => x.GetHealthCheck(id), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_StorePlayerDetailsChanges()
        {
            HealthCheckEvidention health = new HealthCheckEvidention();
            Person player = new Person();
            Contract contract = new Contract();
            Organization org = new Organization();

            var repository = new Mock<IPlayerRepository>();
            repository.Setup(x => x.UpdatePlayer(player));
            repository.Setup(x => x.UpdateContract(contract));
            repository.Setup(x => x.UpdateHealthCheck(health));

            PlayerProcessor processor = new PlayerProcessor();
            processor.Repository = (IPlayerRepository)repository.Object;

            processor.StoreHealthCheckChanges(health);
            processor.StoreContractChanges(contract);

            repository.Verify(x => x.UpdateHealthCheck(health), Times.Exactly(1));
            repository.Verify(x => x.UpdateContract(contract), Times.Exactly(1));
        }

        [TestMethod]
        public void Validate_GenerateTheFixturesForTheSeason()
        {
            int competitionId = 1;
            int seasonId = 3;
            bool allreadyCreated = true;
            List<int> clubIds = new List<int>();

            var repository = new Mock<ISeasonRepository>();
            repository.Setup(x => x.MatchesGenerated(competitionId, seasonId)).Returns(allreadyCreated);
            repository.Setup(x => x.GetIdsOfClubsInCompetition(competitionId, seasonId)).Returns(clubIds);

            SeasonProcessor processor = new SeasonProcessor();
            processor.Repository = (ISeasonRepository)repository.Object;

            var res = processor.GenerateTheFixturesForTheSeason(competitionId, seasonId);

            //vec je generirano, ukoliko zelimo da test ne prođe makni if uvjet
            if (!allreadyCreated)
                repository.Verify(x => x.GetIdsOfClubsInCompetition(competitionId, seasonId), Times.Exactly(1));
            repository.Verify(x => x.MatchesGenerated(competitionId, seasonId));
        }
    }
}
