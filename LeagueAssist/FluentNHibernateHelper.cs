using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueAssist
{
    public class FluentNHibernateHelper
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
    }
}
