﻿using LeagueAssist.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class Class1
    {
        public void Store(object zaSpremanje)
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();

            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(zaSpremanje);
                    
                    var S201516 = new Season { Name = "2015/2016" };
                    var fixture = new Fixture { Name = "1. kolo" };

                    session.SaveOrUpdate(S201516);
                    session.SaveOrUpdate(fixture);

                    transaction.Commit();
                }
            }
        }
        public List<Country> GetAll()
        {
            var sessionFactory = FluentNHibernateHelper.CreateSessionFactory();
            var allCountries = new List<Country>();
            using (var session = sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    allCountries = (List<Country>)session.QueryOver<Country>().List();
                    transaction.Commit();
                }
            }
            return allCountries;
        }
    }
}
