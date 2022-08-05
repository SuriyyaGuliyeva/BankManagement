using BankManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.IRepository
{
    public interface IBankRepository
    {
        //crud
        //get list
        Task<IEnumerable<Bank>> GetBanks();
        //Task<List<Bank>> GetBanks();

        //get ID
        Task<Bank> GetBank(int id);

        //create (add)
        Task<int> AddBank(Bank bank);
        //Task<Bank> AddBank(Bank bank);

        //update (edit)
        //Task<int> EditBank(Bank bank);
        Task<Bank> EditBank(Bank bank);

        //delete
        Task DeleteBank(Bank bank);
    }
}
