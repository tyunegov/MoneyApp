using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.Repository
{
    public interface ITransactionRepository
    {
        IEnumerable<TransactionModel> GetAll();
    }
}
