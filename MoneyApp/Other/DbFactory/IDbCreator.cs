using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other.DbFactory
{
    public abstract class IDbCreator
    {
        public static void CreateDbIfNotExist() { }
    }
}
