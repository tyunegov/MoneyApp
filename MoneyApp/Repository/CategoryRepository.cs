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

        public IEnumerable<Category> MainCategory(int typeId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {                
                return db.Query<Category, TypeTransactionModel, Category>(
                    @$"SELECT * FROM dbo.Category c
                    inner join TypeTransaction tt on tt.Id = c.TypeId
                    Where c.typeId ={typeId} AND c.CategoryId IS NULL
                    order by c.Name",
                    (c, tt) =>
                    {
                        c.Type = tt;
                        return c;
                    }
                    );
            }
        }

        public IEnumerable<Category> SubCategory(int categoryId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<SubCategoryModel, TypeTransactionModel, Category, Category>(
                    @$"SELECT * FROM dbo.Category c
                    inner join TypeTransaction tt on tt.Id = c.TypeId
                    inner join Category mc on mc.Id = c.CategoryId
                    Where c.CategoryId ={categoryId}
                    order by c.Name",
                    (sc, tt, c) =>
                    {
                        c.Type = tt;
                        c.SubCategory = sc;
                        return c;
                    }
                    );
            }
        }
    }
}
