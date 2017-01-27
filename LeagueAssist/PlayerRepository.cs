using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public interface IPlayerRepository
    {
        PlayerDetails GetPlayerDetails(int playerId);
        Person GetPlayer(int playerId);
        Contract GetContract(int contractId);
        HealthCheckEvidention GetHealthCheck(int healthCheckId);
        void UpdatePlayer(Person player);
        void UpdateContract(Contract contract);
        void UpdateHealthCheck(HealthCheckEvidention healthCheck);
    }
    public class PlayerRepository : IPlayerRepository
    {
        public PlayerDetails GetPlayerDetails(int playerId)
        {
            var result = new PlayerDetails();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (PlayerDetails)session.QueryOver<PlayerDetails>().Where(x => x.Id == playerId).OrderBy(x => x.DateTo).Desc.List().First();
                    //transaction.Commit();
                }
            }
            return result;
        }

        public Person GetPlayer(int playerId)
        {
            var result = new Person();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Person)session.QueryOver<Person>().Where(x => x.Id == playerId).List().First();
                    transaction.Commit();
                }
            }
            return result;
        }

        public Contract GetContract(int contractId)
        {
            var result = new Contract();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (Contract)session.QueryOver<Contract>().Where(x => x.Id == contractId).List().First();
                    transaction.Commit();
                }
            }
            return result;
        }

        public HealthCheckEvidention GetHealthCheck(int healthCheckId)
        {
            var result = new HealthCheckEvidention();
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    result = (HealthCheckEvidention)session.QueryOver<HealthCheckEvidention>().Where(x => x.Id == healthCheckId).List().First();
                    transaction.Commit();
                }
            }
            return result;
        }

        public void UpdatePlayer(Person player)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(player);
                    transaction.Commit();
                }
            }
        }

        public void UpdateContract(Contract contract)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(contract);
                    transaction.Commit();
                }
            }
        }

        public void UpdateHealthCheck(HealthCheckEvidention healthCheck)
        {
            var clas = new Class1();
            using (var session = clas.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    session.SaveOrUpdate(healthCheck);
                    transaction.Commit();
                }
            }
        }
    }
}
