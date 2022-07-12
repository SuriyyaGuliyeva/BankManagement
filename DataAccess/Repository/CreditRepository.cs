using BankManagement.Context;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.Repository
{
    public class CreditRepository : ICreditRepository
    {
        private readonly BankContext _bankContext;

        public CreditRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<Credit> AddCredit(Credit credit)
        {
            await _bankContext.Credits.AddAsync(credit);
            await _bankContext.SaveChangesAsync();
            return credit;
        }

        public async Task DeleteCredit(Credit credit)
        {
            _bankContext.Credits.Remove(credit);
            await _bankContext.SaveChangesAsync();
        }

        public async Task<Credit> EditCredit(Credit credit)
        {
            _bankContext.Credits.Update(credit);
            await _bankContext.SaveChangesAsync();
            return credit;
        }

        public async Task<Credit> GetCredit(int id)
        {
            Credit credit = await _bankContext.Credits.Where(cr => cr.Id == id).FirstOrDefaultAsync();
            return credit;
        }

        public async Task<List<Credit>> GetCredits()
        {
            var credits = await _bankContext.Credits.ToListAsync();
            return credits;
        }
    }
}
