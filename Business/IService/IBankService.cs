using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
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
        Task<CreateBankResponseModel> AddBank(CreateBankRequestModel bankRequest);

        //update (edit)
        Task<Bank> EditBank(Bank bank);

        //delete
        Task<bool> DeleteBank(int id);
    }
}
