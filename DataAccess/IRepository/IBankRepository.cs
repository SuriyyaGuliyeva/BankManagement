using BankManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.IRepository
{
    public interface IBankRepository
    {
        //crud
        //get
        Task<List<Bank>> GetBanks();

        //get ID
        Task<Bank> GetBank(int id);

        //create (add)
        Task<Bank> AddBank(Bank bank);

        //update (edit)
        Task<Bank> EditBank(Bank bank);

        //delete
        Task DeleteBank(Bank bank);
    }
}
