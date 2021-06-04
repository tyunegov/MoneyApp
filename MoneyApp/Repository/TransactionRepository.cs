using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Models;
using MoneyApp.Other;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MoneyApp.Repository
{
    public class TransactionRepository<TM> : ITransactionRepository<TM> where TM:TransactionModel
    {
        private string connectionString;

        public TransactionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<TM> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<TM, TypeTransactionModel, TM>(
                    @"SELECT * FROM dbo.Transactions t
                    inner join TypeTransaction tt on tt.Id = t.TypeId
                    order by t.Date desc",
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
                db.Execute($"DELETE FROM Transactions WHERE Id = {id}");
            }
        }

        public TM Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sql = $"SELECT TOP 1 * FROM Transactions t inner join TypeTransaction tt on tt.Id = t.TypeId WHERE t.Id = {id}"; 

                return db.Query<TM, TypeTransactionModel, TM>(
                    sql, 
                    (t, tt) =>
                    {
                        t.Type = tt;
                        return t;
                    })
                    .FirstOrDefault();
            }
        }

        public TransactionStatus Insert(ref TM transaction)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //Проверяем наличие TypeId в БД
                string sql = $"SELECT TOP 1 Id FROM TypeTransaction Where Id = '{transaction.Type.Id}'";
                int typeId = db.Query<int>(sql).FirstOrDefault();
                //При отсутствии возвращаем NotFound
                if (typeId == 0)
                {
                    return TransactionStatus.NotFound;
                }
                //Пробуем сделать запись транзакции
                var sqlQuery = $"DECLARE @ID int;" +
                               $"INSERT INTO Transactions (Date, TypeId, Amount, Description)" +
                                    $"VALUES('{transaction.Date}'," +
                                    $"{transaction.Type.Id}," +
                                    $"{transaction.Amount.ToString().Replace(",",".")}, " +
                                    $"'{transaction.Description}');" +
                               $"SET @ID = SCOPE_IDENTITY();" +
                               $"SELECT @ID";
                int id = db.Query<int>(sqlQuery).FirstOrDefault();
                //Если запись не произошла, возвращаем 0
                if(id==0)
                    return TransactionStatus.FailedToWriteTransaction;
                //Если все успешно, возвращаем 1, transaction меняется на тот, что в БД
                transaction = Get(id);
                return TransactionStatus.Success;
            }
        }

        public TransactionStatus Update(int id, ref TM transaction)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                //Проверяем наличие транзакции в БД
                TM _transaction = Get(id);
                //При отсутствии возвращаем -1
                if (_transaction == null)
                {
                    return TransactionStatus.NotFound;
                }
                //Пробуем изменить транзакцию
                var sqlQuery = $"Update Transactions" +
                                    $"Set (" +
                                    $"Date = '{transaction.Date}'," +
                                    $"TypeId = '{transaction.Type.Id}'," +
                                    $"Amount = '{transaction.Amount}', " +
                                    $"Description = '{(transaction.Description == null ? _transaction.Description : transaction.Description)}';)";
                transaction = Get(id);
                return TransactionStatus.Success;
            }
        }

        public IEnumerable<AGroupT> Period<AGroupT>(DateTime startDate, DateTime endDate) where AGroupT : AmountGroupTypeDTOModel
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @"SELECT t.TypeId, SUM(t.Amount) as Amount, tt.Id, tt.Type 
                    FROM [MoneyApp].[dbo].[Transactions] t
                    INNER JOIN TypeTransaction tt on tt.Id = t.TypeId " +
                    $"WHERE [Date]>='{startDate}' " +
                    $@"AND [Date]<='{endDate} '
                    group by t.TypeId,tt.Id, tt.Type";
                return db.Query<AGroupT, TypeTransactionModel, AGroupT>(
                    sql,
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