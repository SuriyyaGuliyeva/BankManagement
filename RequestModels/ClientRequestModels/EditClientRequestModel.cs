namespace BankManagement.RequestModels
{
    public class EditClientRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Fin { get; set; }
    }
}
