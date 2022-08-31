using BankManagement.Context;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
using BankManagement.ResponseModels.CreditResponseModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.Repository
{
    public class CreditRepository : ICreditRepository
    {
        private readonly BankContext _bankContext;
        private readonly IDbConnection _dbConnection;

        public CreditRepository(BankContext bankContext, IConfiguration configuration)
        {
            _bankContext = bankContext;
            _dbConnection = new SqlConnection(configuration.GetConnectionString("ConnectionString"));
        }

        public async Task<Credit> AddCredit(Credit credit)
        {
            await _bankContext.Credits.AddAsync(credit);
            await _bankContext.SaveChangesAsync();
            return credit;
        }

        public async Task DeleteCredit(Credit credit)
        {
            _bankContext.Credits.Remove(credit);
            await _bankContext.SaveChangesAsync();
        }

        public async Task<Credit> EditCredit(Credit credit)
        {
            _bankContext.Credits.Update(credit);
            await _bankContext.SaveChangesAsync();
            return credit;
        }

        //with EF
        //public async Task<Credit> GetCredit(int id)
        //{
        //    Credit credit = await _bankContext.Credits.Where(cr => cr.Id == id)
        //        .Include(cr => cr.Bank)
        //        .Include(cr => cr.Client)
        //        .FirstOrDefaultAsync();

        //    return credit;
        //}

        public async Task<Credit> GetCredit(int id)
        {
            var sql = "select * from credits where id = @Id";
            var credit = await _dbConnection.QuerySingleAsync<Credit>(sql, new { Id = id });

            return credit;
        }

        //with EF
        public async Task<List<Credit>> GetCredits()
        {
            List<Credit> credits = await _bankContext.Credits
                .Include(cr => cr.Bank)
                .Include(cr => cr.Client)
                .ToListAsync();
            return credits;
        }

        //with Dapper
        public async Task<List<GetCreditsResponseModel>> GetCreditsWithDapper()
        {
            //string sql = @"select c.Id, CreditAmount, c.CreditRate, StartDate, EndDate, Paid, b.Id as bankId, b.Name as BankName from credits c left join banks b on c.BankId = b.Id";
            string sql = "exec sp_joiningTables";

            List<GetCreditsResponseModel> credits = (await _dbConnection.QueryAsync<GetCreditsResponseModel>(sql, new { })).ToList();
            return credits;
        }
    }
}