using System;

namespace BankManagement.ResponseModels.CreditResponseModels
{
    public class GetCreditResponseModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int BankId { get; set; }
        public string BankName { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal CreditRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Paid { get; set; }
    }
}
