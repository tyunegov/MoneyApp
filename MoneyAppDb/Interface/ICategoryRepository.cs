using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.IRepository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> MainCategory(int typeId);
        IEnumerable<CategoryModel> GetCategory(int? id, int? typeId);
    }
}
