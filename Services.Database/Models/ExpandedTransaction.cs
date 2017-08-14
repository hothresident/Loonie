using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Database.Models
{
    public partial class ExpandedTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int TransactionId { get; set; }

        public decimal? Amount { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(100)]
        public string Memo { get; set; }

        public virtual Category Category { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
