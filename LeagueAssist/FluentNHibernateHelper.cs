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
    public static class FluentNHibernateHelper
    {
        public static ISessionFactory CreateSessionFactory()
        {
            string connectionString = "server=cfd38af2-9264-4bf2-900a-a6e2015e53e3.mysql.sequelizer.com;database=dbcfd38af292644bf2900aa6e2015e53e3;uid=uktzclynyotubsgo;pwd=vpkCLYtAPNS8jx3JtUcQtHQSEBCJBPQvyXgtFwA8etpzRavHNjBpQGpUGz7iuS8a";
            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                  .ConnectionString(connectionString).ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Class1>())
                .BuildSessionFactory();
            return sessionFactory;
        }
    }
}