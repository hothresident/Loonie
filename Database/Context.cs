using Core.Domain.Models;
using System.Data.Entity;

namespace Database.Services
{
    public class Context : DbContext
    {
        public Context() : base()
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transacations { get; set; }
    }
}
