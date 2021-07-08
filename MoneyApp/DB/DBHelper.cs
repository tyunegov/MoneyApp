using MoneyAppDb.Other.DbFactory;

namespace MoneyApp.Repository
{
    internal static class DBHelper
    {
        internal static readonly string CONNECTION_STRING = @"Data Source=DESCKTOP\SQLEXPRESS;Initial Catalog=MoneyApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        internal static readonly string TYPE_TRANSACTION = "[dbo].[TypeTransaction]";
        internal static readonly string CATEGORY = "[dbo].[Category]";
        internal static readonly string TRANSACTION = "[dbo].[Transactions]";

        internal static void FirstInitDB()
        {
            TypeTransactionInit.CreateDbIfNotExist();
            CategoryInit.CreateDbIfNotExist();
            TransactionInit.CreateDbIfNotExist();
        }
    }
}
    