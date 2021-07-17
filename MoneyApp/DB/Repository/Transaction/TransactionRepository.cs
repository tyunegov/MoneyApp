using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Interface.Transaction;
using MoneyApp.Models;
using MoneyApp.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MoneyApp.Db.Repository.Transaction
{
    public class TransactionRepository : ITransactionRepository 
    {
        private string ConnectionString { get { return DBHelper.CONNECTION_STRING; } }

        public bool Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sqlQuery = $@"DELETE FROM Transactions 
                                  WHERE Id = {id}
                                  SELECT TOP 1 id from Transactions";
                return db.Query<int>(sqlQuery).FirstOrDefault()==id?false:true;
            }
        }

        public IEnumerable<TransactionModel> Get(int? id)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sql = $"SELECT {(id != null ? "TOP 1" : "")} * FROM Transactions t " +
                     $"inner join Category ct on ct.Id = t.CategoryId " +
                     $"inner join TypeTransaction tt on tt.Id = ct.TypeId " +
                     $"WHERE 1=1 " +
                     $"{(id != null ? "AND t.Id = "+id : "")}";

                return db.Query<TransactionModel, CategoryModel, TypeTransactionModel, TransactionModel>(
                    sql,
                    (t, ct, tt) =>
                    {
                        t.Category = ct;
                        ct.Type = tt;
                        return t;
                    });
            }
        }

        public TransactionModel Insert(TransactionModel transaction)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $@"DECLARE @ID int;
                               INSERT INTO Transactions (Date, CategoryId, Amount, Description, UserId)
                                    VALUES('{transaction.Date}',
                                    {transaction.Category.Id},
                                    {transaction.Amount.ToString().Replace(",", ".")}, 
                                    '{transaction.Description}',
                                    '{transaction.UserId}');
                               SET @ID = SCOPE_IDENTITY();
                               SELECT * from
							   Transactions
							   where id = @ID";
                return db.Query<TransactionModel>(sqlQuery).FirstOrDefault();
            }
        }

        public TransactionModel Update(int id, ref TransactionModel transaction)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                var sqlQuery = $@"Update Transactions
                                    Set
                                    Date = '{transaction.Date}',
                                    CategoryId = '{transaction.Category.Id}',
                                    Amount = '{transaction.Amount}', 
                                    Description = '{(transaction.Description)}',
                                    UserId = '{transaction.UserId}'
                                    Where Id={id}
                               SELECT * from [dbo].[Transactions] 
                                                    where Id={id}";
                return db.Query<TransactionModel>(sqlQuery).FirstOrDefault();
            }
        }

        public IEnumerable<AmountGroupTypeDTOModel> Period(int userId, DateTime startDate, DateTime endDate)
        {
            using (IDbConnection db = new SqlConnection(ConnectionString))
            {
                string sql = @$"SELECT ct.TypeId, SUM(t.Amount) as Amount, tt.Id, tt.Name 
                        FROM [MoneyApp].[dbo].[Transactions] t
                        INNER JOIN Category ct on ct.Id = t.CategoryId 
                        INNER JOIN TypeTransaction tt on tt.Id = ct.TypeId 
                        WHERE [Date]>='{startDate}' 
                        AND [Date]<='{endDate}'
                        AND [UserId] = {userId}
                        group by ct.TypeId, tt.Id, tt.Name";
                return db.Query<AmountGroupTypeDTOModel, TypeTransactionModel, AmountGroupTypeDTOModel>(
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

