using System.Collections.Generic;

namespace Core.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public IEnumerable<Transaction> Transacation { get; set; }
    }
}
