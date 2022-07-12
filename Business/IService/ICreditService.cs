using BankManagement.Entities;
using BankManagement.RequestModels.CreditRequestModels;
using BankManagement.ResponseModels.CreditResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.IService
{
    public interface ICreditService
    {
        Task<List<Credit>> GetCredits();
        Task<Credit> GetCredit(int id);
        Task<CreateCreditResponseModel> AddCredit(CreateCreditRequestModel credit);
        Task<Credit> EditCredit(Credit credit);
        Task<bool> DeleteCredit(int id);
    }
}
