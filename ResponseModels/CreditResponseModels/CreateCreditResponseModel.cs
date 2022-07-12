using BankManagement.Entities;
using System;

namespace BankManagement.ResponseModels.CreditResponseModels
{
    public class CreateCreditResponseModel
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public Bank Bank { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal CreditRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Paid { get; set; }
    }
}
