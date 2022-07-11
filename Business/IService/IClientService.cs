using BankManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.Business.IService
{
    public interface IClientService
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClient(int id);
        Task<Client> AddClient(Client client);
        Task<Client> EditClient(Client client);
        Task<bool> DeleteClient(int id);
    }
}
