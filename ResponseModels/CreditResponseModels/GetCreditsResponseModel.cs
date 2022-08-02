using BankManagement.Entities;
using System;

namespace BankManagement.ResponseModels.CreditResponseModels
{
    public class GetCreditsResponseModel
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public string BankName { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal CreditRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Paid { get; set; }
    }
}
