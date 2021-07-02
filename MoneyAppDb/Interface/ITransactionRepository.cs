using MoneyApp.Models;
using System;
using System.Collections.Generic;

namespace MoneyApp.IRepository
{
    public interface ITransactionRepository
    {
        void Delete(int id);
        IEnumerable<TransactionModel> Get(int? id);
        void Insert(ref TransactionModel transaction);
        void Update(int id, ref TransactionModel transaction);
        IEnumerable<AGroupT> Period<AGroupT>(DateTime startDate, DateTime endDate) where AGroupT : AmountGroupTypeDTOModel;
    }
}
