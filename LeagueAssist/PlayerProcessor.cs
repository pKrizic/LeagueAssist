using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueAssist.Entities;

namespace LeagueAssist
{
    public class PlayerProcessor
    {
        private IPlayerRepository _playerRepository;

        public IPlayerRepository Repository
        {
            get { return _playerRepository; }
            set { _playerRepository = value; }
        }

        public PlayerProcessor()
        {
            _playerRepository = new PlayerRepository();
        }

        public PlayerDetails RetrievePlayerDetails(int playerId)
        {
            PlayerDetails result = _playerRepository.GetPlayerDetails(playerId);
            return result;
        }

        public Person RetrievePlayer(int playerId)
        {
            Person player = _playerRepository.GetPlayer(playerId);
            return player;
        }

        public Contract RetrieveContract(int contractId)
        {
            Contract contract = _playerRepository.GetContract(contractId);
            return contract;
        }

        public HealthCheckEvidention RetrieveHealthCheck(int healthCheckId)
        {
            HealthCheckEvidention healthCheck = _playerRepository.GetHealthCheck(healthCheckId);
            return healthCheck;
        }

        public void StorePlayerDetailsChanges(Person player, Contract contract, HealthCheckEvidention healthCheck, Organization organization)
        {
            StorePlayerChanges(player);

            if (contract.Id == 0)
            {
                contract.Person = player;
                contract.Organization = organization;
                StoreNewContract(contract);
            } else
            {
                StoreContractChanges(contract);
            }
            
            if (healthCheck.Id == 0)
            {
                healthCheck.Player = player;
                StoreNewHealthCheck(healthCheck);
            } else
            {
                StoreHealthCheckChanges(healthCheck);
            }
        }

        public void StorePlayerChanges(Person player)
        {
            var _player = RetrievePlayer(player.Id);
            _player.FirstName = player.FirstName;
            _player.LastName = player.LastName;
            _player.BirthDate = player.BirthDate;
            _player.Email = player.Email;
            _player.Phone = player.Phone;

            _playerRepository.UpdatePlayer(_player);
        }

        public void StoreContractChanges(Contract contract)
        {
            var _contract = RetrieveContract(contract.Id);

            _contract.DateFrom = contract.DateFrom;
            _contract.DateTo = contract.DateTo;
            _contract.AnnualSalary = contract.AnnualSalary;
            _contract.NumberOnShirt = contract.NumberOnShirt;
            _contract.Foreigner = contract.Foreigner;

            _playerRepository.UpdateContract(_contract);
        }

        public void StoreHealthCheckChanges(HealthCheckEvidention healthCheck)
        {
            var _healthCheck = RetrieveHealthCheck(healthCheck.Id);

            _healthCheck.FromDate = healthCheck.FromDate;
            _healthCheck.ToDate = healthCheck.ToDate;
            _healthCheck.Remark = healthCheck.Remark;

            _playerRepository.UpdateHealthCheck(_healthCheck);
        }

        public void StoreNewHealthCheck(HealthCheckEvidention healthCheck)
        {
            var _healthCheck = new HealthCheckEvidention(healthCheck);
            _playerRepository.UpdateHealthCheck(_healthCheck);
        }

        public void StoreNewContract(Contract contract)
        {
            var _contract = new Contract(contract);
            _playerRepository.UpdateContract(_contract);
        }
    }
}
