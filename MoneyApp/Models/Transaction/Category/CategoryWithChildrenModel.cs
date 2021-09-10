using MoneyApp.Models.Transaction.Category;
using System.Collections.Generic;

namespace MoneyApp.Models
{
    public class CategoryWithChildrenModel:CategoryWithTypeModel
    {
        public IEnumerable<CategoryModel> SubCategory { get; set; }
    }
}