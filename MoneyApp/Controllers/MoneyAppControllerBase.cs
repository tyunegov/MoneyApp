using MoneyApp.Db.Repository;
using MoneyApp.DB.Interface.Repository;
using MoneyApp.Interface.Repository;
using MoneyApp.Other.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Controllers
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
