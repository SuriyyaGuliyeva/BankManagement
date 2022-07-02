using BankManagement.Business.IService;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.Service
{
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        public BankService(IBankRepository bankRepository)
        {
            _bankRepository = bankRepository;
        }
        public async Task<Bank> AddBank(Bank bank)
        {
            return await _bankRepository.AddBank(bank);
        }

        public async Task<bool> DeleteBank(int id)
        {
            Bank bank = await _bankRepository.GetBank(id);
            if (bank is null)
            {
                return false;
            }
            await _bankRepository.DeleteBank(bank);
            return true;
        }

        public async Task<Bank> EditBank(Bank bank)
        {
            return await _bankRepository.EditBank(bank);
        }

        public async Task<Bank> GetBank(int id)
        {
            return await _bankRepository.GetBank(id);
        }

        public async Task<List<Bank>> GetBanks()
        {
            return await _bankRepository.GetBanks();
        }
    }
}
