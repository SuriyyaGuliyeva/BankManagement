using BankManagement.Entities;
using BankManagement.RequestModels.CreditRequestModels;
using BankManagement.ResponseModels.CreditResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.IService
{
    public interface ICreditService
    {
        Task<List<GetCreditsResponseModel>> GetCredits();        
        Task<GetCreditResponseModel> GetCredit(int id);
        Task<CreateCreditResponseModel> AddCredit(CreateCreditRequestModel credit);
        Task<EditCreditResponseModel> EditCredit(EditCreditRequestModel credit);
        Task<bool> DeleteCredit(int id);
    }
}
