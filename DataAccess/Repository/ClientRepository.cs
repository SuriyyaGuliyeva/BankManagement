using BankManagement.Context;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankContext _bankContext;

        public ClientRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public async Task<Client> AddClient(Client client)
        {
            await _bankContext.Clients.AddAsync(client);
            await _bankContext.SaveChangesAsync();
            return client;
        }
       
        public async Task DeleteClient(Client client)
        {
            _bankContext.Clients.Remove(client);
            await _bankContext.SaveChangesAsync();
        }

        public async Task<Client> EditClient(Client client)
        {
            _bankContext.Clients.Update(client);
            await _bankContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> GetClient(int id)
        {
            Client client = await _bankContext.Clients.Where(c => c.Id == id).FirstOrDefaultAsync();
            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clients = await _bankContext.Clients.ToListAsync();
            return clients;
        }
    }
}
