using BankManagement.Context;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankContext _bankContext;
        private readonly IDbConnection _dbConnection;

        public ClientRepository(BankContext bankContext, IConfiguration configuration)
        {
            _bankContext = bankContext;
            _dbConnection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
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
            //with EF
            //Client client = await _bankContext.Clients.FindAsync(id);
            //return client;

            //with Dapper
            var sql = "select * from clients where id = @Id";
            Client client = await _dbConnection.QuerySingleAsync<Client>(sql, new { Id = id });

            return client;
        }

        public async Task<List<Client>> GetClients()
        {
            //with EF
            //List<Client> clients = await _bankContext.Clients.ToListAsync();
            //return clients;

            //with Dapper
            var sql = "select * from clients";
            var clients = await _dbConnection.QueryAsync<Client>(sql);

            return clients.ToList();
        }
    }
}
