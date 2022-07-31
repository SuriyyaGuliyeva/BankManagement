using System;

namespace BankManagement.RequestModels.CreditRequestModels
{
    public class EditCreditRequestModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int BankId { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal CreditRate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Paid { get; set; }
    }
}
