using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyApp.Repository
{
    public class TypeTransactionRepository: ITypeTransactionRepository
    {
        private string connectionString;

        public TypeTransactionRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<TypeTransactionModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<TypeTransactionModel>(
                    @"SELECT * FROM dbo.TypeTransaction t");
            }
        }
    }
}
