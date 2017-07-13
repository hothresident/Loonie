using System.Data.Entity;
using Database.Models;

namespace Database
{
    public partial class LoonieModel : DbContext
    {
        public LoonieModel()
            : base("name=LoonieConnection")
        {
        }

        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Category)
                .IsUnicode(false);
        }
    }
}
