using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRoundRobin()
        {
            //arrange
            List<int> ids = new List<int>() { 1,2,3,4,5,6,7,8,9,10 };
            Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>();
            //dict.Add(0, new List<int[]>) ocekivana vrijednost

            //act
            //poziv funkcije

            //assert
            //usporedba rezultata sa ocekivanim Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly"); 
        }
    }
}
