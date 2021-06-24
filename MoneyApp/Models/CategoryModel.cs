using System.ComponentModel.DataAnnotations;

namespace MoneyApp.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required]
        public TypeTransactionModel Type { get; set; }
        [Required]
        public string Name { get; set; }
    }
}