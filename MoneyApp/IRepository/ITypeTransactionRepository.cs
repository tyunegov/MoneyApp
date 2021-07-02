using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.IRepository
{
    public interface ITypeTransactionRepository
    {
        IEnumerable<TypeTransactionModel> GetAll();
    }
}
