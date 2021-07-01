using MoneyApp.Models;
using MoneyApp.Other;
using System;
using System.Collections.Generic;

namespace MoneyApp.Repository
{
    public interface ITransactionRepository<T> where T : TransactionModel
    {
        void Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Get(int? id);
        TransactionStatus Insert(ref T transaction);
        TransactionStatus Update(int id, ref T transaction);
        IEnumerable<AGroupT> Period<AGroupT>(DateTime startDate, DateTime endDate) where AGroupT : AmountGroupTypeDTOModel;
    }
}
