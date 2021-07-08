using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.DB.Interface.Repository
{
    public interface ITypeTransactionRepository
    {
        IEnumerable<TypeTransactionModel> GetAll();
    }
}
