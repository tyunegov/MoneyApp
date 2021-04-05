using System;

namespace MoneyApp.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public TypeTransactionModel Type { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

    }
}
