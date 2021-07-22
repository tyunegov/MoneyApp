using MoneyApp.Models.Transaction.Category;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Models.Transaction
{
    public class CategoryWithParentModel:CategoryWithTypeModel
    {
        public CategoryModel MainCategory { get; set; }
    }
}
