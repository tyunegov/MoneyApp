using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyAppDb
{
    public interface ICategoryRepository<T>
    {
        IEnumerable<T> Get(int? id=null, int? typeId=null);
    }
}
