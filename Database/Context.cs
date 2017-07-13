using Database.Models;
using System.Data.Entity;

namespace Database.Services
{
    public class Context : DbContext
    {
        public Context() : base("conn")
        {
        }

        //public DbSet<Transaction> Transacations { get; set; }
    }
}
