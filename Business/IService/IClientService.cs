using BankManagement.Entities;
using BankManagement.RequestModels;
using BankManagement.ResponseModels;
using BankManagement.ResponseModels.ClientResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.IService
{
    public interface IClientService
    {
        Task<List<GetClientsResponseModel>> GetClients();
        Task<GetClientResponseModel> GetClient(int id);
        Task<CreateClientResponseModel> AddClient(CreateClientRequestModel clientRequest);
        Task<EditClientResponseModel> EditClient(EditClientRequestModel clientRequest);
        Task<bool> DeleteClient(int id);
    }
}
