using MoneyApp.Models;
using System.Collections.Generic;

namespace MoneyApp.Repository
{
    public interface ITransactionRepository
    {
        void Delete(int id);
        IEnumerable<TransactionModel> GetAll();
        TransactionModel Get(int id);
    }
}
