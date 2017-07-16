using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public partial class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(50)]
        public string AccountId { get; set; }

        [StringLength(100)]
        public string Memo { get; set; }

        public decimal? Amount { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public bool? Reconciled { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatePosted { get; set; }
    }
}
