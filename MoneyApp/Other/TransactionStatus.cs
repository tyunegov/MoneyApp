using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other
{
    public enum TransactionStatus
    {
        NotFound=-1,
        FailedToWriteTransaction,
        Success
    }
}
