using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MoneyAppDb.Repository
{
    public class TypeTransactionRepository: ITypeTransactionRepository
    {
        private string connectionString = DBHelper.CONNECTION_STRING;

        public IEnumerable<TypeTransactionModel> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<TypeTransactionModel>(
                    @"SELECT * FROM dbo.TypeTransaction t");
            }
        }

        public int GetCount()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>(
                    @"SELECT COUNT(Id) FROM dbo.TypeTransaction t").FirstOrDefault();
            }
        }
    }
}
