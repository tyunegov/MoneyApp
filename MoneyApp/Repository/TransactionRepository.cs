using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MoneyApp.Repository
{
    public class TransactionRepository : ITransactionRepository
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
                return db.Query<TransactionModel, TypeTransactionModel, TransactionModel>(
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

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                db.Execute($"DELETE FROM Users WHERE Id = {id}");
            }
        }

        public TransactionModel Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sql = $"SELECT * FROM Transactions t inner join TypeTransaction tt on tt.Id = t.TypeId WHERE t.Id = {id}"; 

                return db.Query<TransactionModel, TypeTransactionModel, TransactionModel>(
                    sql, 
                    (t, tt) =>
                    {
                        t.Type = tt;
                        return t;
                    })
                    .FirstOrDefault();
            }
        }
    }
}