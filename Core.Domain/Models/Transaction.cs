using Core.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Core.Domain.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public TransactionType Type { get; set; }
        //public string AccountId { get; set; }
        public string Memo { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public bool Reconciled { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<ExpandedTransaction> ExpandedTransactions { get; set; }
    }
}
