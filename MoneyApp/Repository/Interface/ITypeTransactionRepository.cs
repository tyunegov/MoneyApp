using MoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Repository
{
    public interface ITypeTransactionRepository
    {
        IEnumerable<TypeTransactionModel> GetAll();
    }
}
