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
    public class BankRepository : IBankRepository
    {
        private readonly BankContext _bankContext;
        private readonly IDbConnection _dbConnection;

        public BankRepository(BankContext bankContext, IConfiguration configuration)
        {
            _bankContext = bankContext;
            _dbConnection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
        }
        public async Task<Bank> AddBank(Bank bank)
        {
            await _bankContext.Banks.AddAsync(bank);
            await _bankContext.SaveChangesAsync();
            return bank;
        }

        public async Task DeleteBank(Bank bank)
        {
            _bankContext.Banks.Remove(bank);
            await _bankContext.SaveChangesAsync();
        }

        public async Task<Bank> EditBank(Bank bank)
        {
            _bankContext.Banks.Update(bank);
            await _bankContext.SaveChangesAsync();
            return bank;
        }

        public async Task<Bank> GetBank(int id)
        {
            //with Dapper
            var sql = "select * from Banks where id = @Id";
            var bank = await _dbConnection.QuerySingleAsync<Bank>(sql, new { Id = id });

            return bank;

            //with EF
            //Bank bank = await _bankContext.Banks.Where(b => b.Id == id).FirstOrDefaultAsync();
            //return bank;
        }  

        public async Task<List<Bank>> GetBanks()
        {
            //with Dapper
            var sql = "select * from Banks";
            var banks = await _dbConnection.QueryAsync<Bank>(sql);

            return banks.ToList();

            //with EF
            //List<Bank> banks = await _bankContext.Banks.ToListAsync();
            //return banks;
        }
    }
}
