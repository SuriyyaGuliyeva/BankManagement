using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankManagement.Entities
{
    public class Bank
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal CreditRate { get; set; }
        public ICollection<Credit> Credits { get; set; }

        public static implicit operator Bank(List<Bank> v)
        {
            throw new NotImplementedException();
        }
    }
}
