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
        Task<IEnumerable<GetBanksResponseModel>> GetBanks();
        //Task<List<GetBanksResponseModel>> GetBanks();

        //get ID
        Task<GetBankResponseModel> GetBank(int id);

        //create (add)
        Task<CreateBankResponseModel> AddBank(CreateBankRequestModel bankRequest);

        //update (edit)
        Task<EditBankResponseModel> EditBank(EditBankRequestModel bankRequest);

        //delete
        Task<bool> DeleteBank(int id);
    }
}
