using BankManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.IService
{
    public interface IBankService
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
        Task<bool> DeleteBank(int id);
    }
}
