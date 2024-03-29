﻿using BankManagement.Entities;
using BankManagement.ResponseModels.CreditResponseModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankManagement.DataAccess.IRepository
{
    public interface ICreditRepository
    {
        Task<List<GetCreditsResponseModel>> GetCreditsWithDapper();
        Task<List<Credit>> GetCredits();
        Task<Credit> GetCredit(int id);
        Task<Credit> AddCredit(Credit credit);
        Task<Credit> EditCredit(Credit credit);
        Task DeleteCredit(Credit credit);
    }
}
