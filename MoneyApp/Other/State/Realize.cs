using MoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other.State
{
    public class Realize<R,T> where T:TransactionModel
    {
        public R State()
        {
            T model = null;
            return new CategoryState<R,T>().Create(model);
        }
    }
}
