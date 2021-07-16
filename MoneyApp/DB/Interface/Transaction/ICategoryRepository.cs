using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.Interface.Transaction
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> Get(int? id=null, int? typeId=null);
    }
}
