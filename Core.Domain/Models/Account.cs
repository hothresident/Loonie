using System.Collections.Generic;

namespace Core.Domain.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Transaction> Transacation { get; set; }
    }
}
