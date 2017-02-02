using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LeagueAssist.Entities;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{

    public class Class1
    {
        private static ISessionFactory _sessionFactory;

        public ISession OpenSession()
        {
            try
            {
                if (_sessionFactory == null)
                    _sessionFactory = OpenSessionFactory();

                ISession session = _sessionFactory.OpenSession();
                return session;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }

        private ISessionFactory OpenSessionFactory()
        {
            string connectionString = "server=cfd38af2-9264-4bf2-900a-a6e2015e53e3.mysql.sequelizer.com;database=dbcfd38af292644bf2900aa6e2015e53e3;uid=uktzclynyotubsgo;pwd=vpkCLYtAPNS8jx3JtUcQtHQSEBCJBPQvyXgtFwA8etpzRavHNjBpQGpUGz7iuS8a";
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                  .ConnectionString(connectionString).ShowSql().FormatSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Class1>())
                .BuildSessionFactory();
            return _sessionFactory;
        }

        public void Store(object zaSpremanje)
        {
            using (var session = OpenSession())
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

    }
}
