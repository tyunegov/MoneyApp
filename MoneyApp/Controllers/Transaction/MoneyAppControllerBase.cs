using MoneyApp.Db.Repository.Transaction;
using MoneyApp.Interface.Repository.Transaction;
using MoneyApp.Other.State;

namespace MoneyApp.Controllers.Transaction
{
    public abstract class MoneyAppControllerBase
    {
        public ITypeTransactionRepository TypeTransactionRepository => new TypeTransactionRepository();
        public ITransactionRepository TransactionRepository => new TransactionRepository();
        public ICategoryRepository CategoryRepository => new CategoryRepository();
        public TransactionState TransactionState => new TransactionState();
        public CategoryState CategoryState => new CategoryState();
    }
}
