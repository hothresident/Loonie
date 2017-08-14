using Database.Models;
using System.Data.Entity;

namespace Database
{
    public partial class LoonieContext : DbContext
    {
        public LoonieContext()
            : base("name=LoonieConnection")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ExpandedTransaction> ExpandedTransactions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.AccountNumber)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Type)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Transactions)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<ExpandedTransaction>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<ExpandedTransaction>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Type)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Memo)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Transaction>()
                .HasMany(e => e.ExpandedTransactions)
                .WithRequired(e => e.Transaction)
                .WillCascadeOnDelete(false);
        }
    }
}
