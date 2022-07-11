using BankManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.IRepository
{
    public interface IClientRepository
    {
        //get
        Task<List<Client>> GetClients();

        //get ID
        Task<Client> GetClient(int id);

        //create
        Task<Client> AddClient(Client client);

        //update
        Task<Client> EditClient(Client client);

        //delete
        Task DeleteClient(Client client);
    }
}
