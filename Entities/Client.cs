using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BankManagement.Entities
{
    public class Client
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Fin { get; set; }

        public ICollection<Credit> Credits { get; set; }
    }
}
