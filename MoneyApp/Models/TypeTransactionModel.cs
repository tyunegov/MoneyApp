using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Models
{
    public class TypeTransactionModel
    {
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
    }
}