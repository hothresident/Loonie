using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models
{
    public partial class Transaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transaction()
        {
            ExpandedTransactions = new HashSet<ExpandedTransaction>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public int AccountId { get; set; }

        [StringLength(100)]
        public string Memo { get; set; }

        public decimal? Amount { get; set; }

        public int? CategoryId { get; set; }

        public bool? Reconciled { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DatePosted { get; set; }

        public virtual Account Account { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExpandedTransaction> ExpandedTransactions { get; set; }
    }
}
