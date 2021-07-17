using MoneyApp.Models;
using System;
using System.Collections.Generic;

namespace MoneyApp.Interface.Transaction
{
    public interface ITransactionRepository
    {
        bool Delete(int id);
        IEnumerable<TransactionModel> Get(int? id);
        TransactionModel Insert(TransactionModel transaction);
        TransactionModel Update(int id, ref TransactionModel transaction);
        IEnumerable<AmountGroupTypeDTOModel> Period(int userId, DateTime startDate, DateTime endDate);
    }
}
