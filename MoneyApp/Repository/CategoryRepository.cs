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
    public class CategoryRepository<Category>: ICategoryRepository<Category> where Category : CategoryModel
    {
        private string connectionString;

        public CategoryRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IEnumerable<Category> All()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Category>(
                    @"SELECT * FROM dbo.Category c");
            }
        }
    }
}
