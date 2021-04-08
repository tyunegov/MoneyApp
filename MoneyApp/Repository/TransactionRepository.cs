using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Models;
using System.Collections.Generic;
using System.Data;

namespace MoneyApp.Repository
{
    public class TransactionRepository:ITransactionRepository
    {
        private string connectionString;

        public TransactionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<TransactionModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return (IEnumerable<TransactionModel>)db.QueryAsync<TransactionModel, TypeTransactionModel, TransactionModel>(
                    @"SELECT * FROM dbo.Transactions t
                    inner join TypeTransaction tt on tt.Id = t.TypeId",
                    (t, tt) =>
                    {
                        t.Type = tt;
                        return t;
                     }
                    );
            }
        }
    }
}