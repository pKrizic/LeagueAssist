using LeagueAssist;
using LeagueAssist.Entities;
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
            var test = new Class1();
            var c = new Country { Name = "Slovenija" };
            test.Store(c);
            Console.WriteLine("Spremljeno");
            Console.ReadKey();
        }
    }
}
