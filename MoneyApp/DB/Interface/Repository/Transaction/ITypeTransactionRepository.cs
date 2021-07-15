using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.Interface.Repository.Transaction
{
    public interface ITypeTransactionRepository
    {
        IEnumerable<TypeTransactionModel> GetAll();
    }
}
