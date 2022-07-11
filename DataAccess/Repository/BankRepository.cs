using BankManagement.Context;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.Repository
{
    public class BankRepository : IBankRepository
    {     
        private readonly BankContext _bankContext;
        public BankRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }

        public async Task<Bank> AddBank(Bank bank)
        {
            await _bankContext.Banks.AddAsync(bank);
            await _bankContext.SaveChangesAsync();
            return bank;
        }

        public async Task DeleteBank(Bank bank)
        {
            _bankContext.Banks.Remove(bank);
            await _bankContext.SaveChangesAsync();
        }

        public async Task<Bank> EditBank(Bank bank)
        {
            _bankContext.Banks.Update(bank);
            await _bankContext.SaveChangesAsync();
            return bank;
        }

        public async Task<Bank> GetBank(int id)
        {
            Bank bank = await _bankContext.Banks.Where(b => b.Id == id).FirstOrDefaultAsync();
            return bank;
        }

        public async Task<List<Bank>> GetBanks()
        {
            List<Bank> banks = await _bankContext.Banks.ToListAsync();
            return banks;
        }
    }
}
