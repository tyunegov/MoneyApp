using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public TypeTransactionModel Type { get; set; }
        [Required]
        public decimal? Amount { get; set; }
        public string Description { get; set; }

    }
}
