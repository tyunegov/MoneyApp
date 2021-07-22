using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models.Transaction.Category
{
    public class CategoryWithTypeModel:CategoryModel
    {
        [Required]
        public TypeTransactionModel Type { get; set; }
    }
}
