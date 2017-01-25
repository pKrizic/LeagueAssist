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
        public void Validate_Login()
        {
            string username = "Testkgfhfo";
            string password = "123456";
            User user = new User();

            var repository = new Mock<IUserRepository>();
            repository.Setup(x => x.GetUserByUsernameAndPassword(username, password)).Returns(user);

            DataProcessor processor = new DataProcessor();
            processor.Repository = (IUserRepository)repository.Object;

            var res = processor.ProccesData(username, password);

            repository.Verify(x => x.GetUserByUsernameAndPassword(username, password), Times.Exactly(1));
        }
    }
}
