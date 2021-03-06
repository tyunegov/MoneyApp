using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.Interface.Transaction;
using MoneyApp.Models;
using MoneyApp.Repository;
using System.Collections.Generic;
using System.Data;

namespace MoneyApp.Db.Repository.Transaction
{
    public class CategoryRepository : ICategoryRepository
    {
        private string connectionString;

        public CategoryRepository ()
        {
            this.connectionString = DBHelper.CONNECTION_STRING;
        }

        public IEnumerable<CategoryWithChildrenModel> Get(int? id=null, int? typeId=null)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @$"SELECT {(id != null ? "TOP 1" : "")} * FROM dbo.Category c
                    left join TypeTransaction tt on tt.Id = c.TypeId
                    Where 1=1 
                    {(id != null ? $"AND c.Id ={id} " : "AND c.CategoryId IS NULL")}
                    {(typeId != null ? $"AND c.TypeId ={typeId} " : "")}
                    order by c.Name";
                return db.Query<CategoryWithChildrenModel, TypeTransactionModel, CategoryWithChildrenModel>(
                    sql,
                    (c, tt) =>
                    {
                        c.Type = tt;
                        using (IDbConnection db = new SqlConnection(connectionString))
                        {
                            c.SubCategory = db.Query<CategoryModel>(
                                $@"SELECT * FROM dbo.Category c
                                   Where c.CategoryId={c.Id}");
                        }
                        return c;
                    }
                    );
            }
        }
    }
}
