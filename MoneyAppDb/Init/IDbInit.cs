using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyAppDb.Other.DbFactory
{
    public interface IDbInit
    {
        public static void CreateDbIfNotExist() { }
    }
}
