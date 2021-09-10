using MoneyApp.Models;
using System;
using System.Collections.Generic;

namespace MoneyAppDb
{
    public interface ITransactionRepository<T>
    {
        bool Delete(int id);
        IEnumerable<T> Get(int? id);
        T Insert(T transaction);
        T Update(int id, ref T transaction);
        IEnumerable<AGT> Period<AGT>(DateTime startDate, DateTime endDate);
    }
}
