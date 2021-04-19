using MoneyApp.Models;
using MoneyApp.Other;
using System.Collections.Generic;

namespace MoneyApp.Repository
{
    public interface ITransactionRepository
    {
        void Delete(int id);
        IEnumerable<TransactionModel> GetAll();
        TransactionModel Get(int id);
        TransactionStatus Insert(ref TransactionModel transaction);
        TransactionStatus Update(int id, ref TransactionModel transaction);
    }
}
