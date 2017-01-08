using LeagueAssist;
using LeagueAssist.Entities;
using NhibernateTest.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhibernateTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.Service1Client();
            var req = new CountryRequest();
            req.Id = "1";
            var ime = client.GetCountryName(req);
            var test = new Class1();
            var c = new Country { Name = "Slovenija" };
            test.Store(c);
            Console.WriteLine("Spremljeno");
            Console.ReadKey();
        }
    }
}
