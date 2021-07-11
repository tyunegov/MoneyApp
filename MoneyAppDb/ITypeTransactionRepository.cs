using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyAppDb
{
    public interface ITypeTransactionRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
