using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Models;
using MoneyApp.Other.DbFactory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Other
{
    public static class DB
    {
        public static readonly string CONNECTION_STRING = @"Data Source=DESCKTOP\SQLEXPRESS;Initial Catalog=MoneyApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static readonly string TYPE_TRANSACTION = "[dbo].[TypeTransaction]";
        public static readonly string CATEGORY = "[dbo].[Category]";
        public static readonly string TRANSACTION = "[dbo].[Transactions]";

        public static void FirstInitDB()
        {
            DbTypeTransaction.CreateDbIfNotExist();
            DbCategory.CreateDbIfNotExist();
            DbTransaction.CreateDbIfNotExist();
        }
    }
}
    