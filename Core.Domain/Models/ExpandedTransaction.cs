namespace Core.Domain.Models
{
    public class ExpandedTransaction
    {
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public decimal Amount { get; set; }
        public string Category { get; set; }
        public string Memo { get; set; }
    }
}
