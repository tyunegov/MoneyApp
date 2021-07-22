using MoneyApp.Controllers.Transaction;
using MoneyApp.Models;
using MoneyApp.Models.Transaction;
using System;
using System.Collections.Generic;

namespace MoneyApp.Interface.Transaction
{
    public interface ITransactionRepository
    {
        bool Delete(int id);
        IEnumerable<TransactionModel<CategoryWithParentModel>> Get(int? id);
        TransactionModel<CategoryWithParentModel> Insert(TransactionModel<CategoryModel> transaction);
        TransactionModel<CategoryWithParentModel> Update(int id, ref TransactionModel<CategoryModel> transaction);
        IEnumerable<AmountGroupTypeDTOModel> Period(int userId, DateTime startDate, DateTime endDate);
    }
}
