using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Models;
using System;
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

        public int Post(ref TransactionModel transaction)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //Проверяем наличие TypeId в БД
                string sql = $"SELECT TOP 1 Id FROM TypeTransaction Where Id = '{transaction.Type.Id}'";
                int typeId = db.Query<int>(sql).FirstOrDefault();
                //При отсутствии возвращаем -1
                if (typeId == 0)
                {
                    return -1;
                }
                //Пробуем сделать запись транзакции
                var sqlQuery = $"DECLARE @ID int;" +
                               $"INSERT INTO Transactions (Date, TypeId, Amount, Description)" +
                                    $"VALUES('{transaction.Date}'," +
                                    $"'{transaction.Type.Id}'," +
                                    $"'{transaction.Amount}', " +
                                    $"'{transaction.Description}');" +
                               $"SET @ID = SCOPE_IDENTITY();" +
                               $"SELECT @ID";
                int id = db.Query<int>(sqlQuery).FirstOrDefault();
                //Если запись не произошла, возвращаем 0
                if(id==0)
                    return 0;
                //Если все успешно, возвращаем 1, transaction меняется на тот, что в БД
                transaction = Get(id);
                return 1;
            }
        }
    }
}