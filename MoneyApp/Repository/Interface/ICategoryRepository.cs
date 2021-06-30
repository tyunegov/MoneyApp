using MoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Repository
{
    public interface ICategoryRepository<Category> where Category : CategoryModel
    {
        IEnumerable<Category> MainCategory(int typeId);
        IEnumerable<Category> SubCategory(int categoryId);
    }
}
