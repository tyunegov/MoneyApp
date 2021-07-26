using Microsoft.AspNetCore.Mvc;
using MoneyApp.Db.Repository.Transaction;
using MoneyApp.Interface.Transaction;
using MoneyApp.Other.State;
using MoneyApp.Other.State.Authorization;

namespace MoneyApp.Controllers.Transaction
{
    public abstract class MoneyAppControllerBase:Controller
    {
        public ITypeTransactionRepository TypeTransactionRepository => new TypeTransactionRepository();
        public ITransactionRepository TransactionRepository => new TransactionRepository();
        public ICategoryRepository CategoryRepository => new CategoryRepository();
        public TransactionState TransactionState => new TransactionState();
        public CategoryState CategoryState => new CategoryState();
        public AccountState AccountState = new AccountState();
    }
}
