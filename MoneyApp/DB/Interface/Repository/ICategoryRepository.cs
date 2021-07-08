using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.Interface.Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryModel> Get(int? id=null, int? typeId=null);
    }
}
