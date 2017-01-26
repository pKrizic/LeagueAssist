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

        public void StorePlayerDetailsChanges(PlayerDetails playerDetails)
        {
            Person player = new Person();
            Contract contract = new Contract();
            HealthCheckEvidention healthCheck = new HealthCheckEvidention();

            player.Id = playerDetails.Id;
            player.FirstName = playerDetails.FirstName;
            player.LastName = playerDetails.LastName;
            player.BirthDate = playerDetails.BirthDate;
            player.Email = playerDetails.Email;
            player.Phone = playerDetails.Phone;

            contract.Id = playerDetails.ContractId;
            contract.DateFrom = playerDetails.DateFrom;
            contract.DateTo = playerDetails.DateTo;
            contract.AnnualSalary = playerDetails.AnnualSalary;
            contract.NumberOnShirt = playerDetails.NumberOnShirt;
            contract.Foreigner = playerDetails.Foreigner;

            healthCheck.Id = playerDetails.HealthCheckId;
            healthCheck.FromDate = playerDetails.FromDate;
            healthCheck.ToDate = playerDetails.ToDate;
            healthCheck.Remark = playerDetails.Remark;

            StorePlayerChanges(player);
            StoreContractChanges(contract);
            StoreHealthCheckChanges(healthCheck);
        }

        public void StorePlayerChanges(Person player)
        {
            var _player = RetrievePlayer(player.Id);
            _player = player;
            _playerRepository.UpdatePlayer(_player);
        }

        public void StoreContractChanges(Contract contract)
        {
            var _contract = RetrieveContract(contract.Id);
            _contract = contract;
            _playerRepository.UpdateContract(_contract);
        }

        public void StoreHealthCheckChanges(HealthCheckEvidention healthCheck)
        {
            var _healthCheck = RetrieveHealthCheck(healthCheck.Id);
            _healthCheck = healthCheck;
            _playerRepository.UpdateHealthCheck(_healthCheck);
        }
    }
}
