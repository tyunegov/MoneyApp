using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.Interface.Transaction
{
    public interface ITypeTransactionRepository
    {
        IEnumerable<TypeTransactionModel> GetAll();
    }
}
