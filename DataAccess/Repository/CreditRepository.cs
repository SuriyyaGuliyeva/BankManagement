using BankManagement.Context;
using BankManagement.DataAccess.IRepository;
using BankManagement.Entities;
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

        public async Task<Credit> GetCredit(int id)
        {
            //with EF
            //Credit credit = await _bankContext.Credits.Where(cr => cr.Id == id)
            //    .Include(cr => cr.Bank)
            //    .Include(cr => cr.Client)
            //    .FirstOrDefaultAsync();

            //return credit;

            //with Dapper           
            var sql = "select * from credits where id = @Id";
            var credit = await _dbConnection.QuerySingleAsync<Credit>(sql, new { Id = id });

            return credit;
        }

        public async Task<List<Credit>> GetCredits()
        {
            //with EF
            //List<Credit> credits = await _bankContext.Credits
            //    .Include(cr => cr.Bank)
            //    .Include(cr => cr.Client)
            //    .ToListAsync();
            //return credits;

            //with Dapper
            //var sql = "select cr.Id, b.Name as BankName, cl.Name as ClientName, cr.CreditRate, cr.CreditAmount, cr.StartDate, cr.EndDate, cr.Paid from credits as cr left join banks as b on b.Id = cr.BankId left join clients as cl on cl.Id = cr.ClientId";

            var sql = @"select c.Id, CreditAmount, c.CreditRate, StartDate, EndDate, Paid, c.BankId as bankId from credits c left join banks b on c.BankId = b.Id";

            var credits = await _dbConnection.QueryAsync<Credit, Bank, Credit>(sql, (credit, bank) => {
                credit.Bank = bank;
                return credit;
            },
            splitOn: "bankId");

            return credits.ToList();  
        }
    }
}
