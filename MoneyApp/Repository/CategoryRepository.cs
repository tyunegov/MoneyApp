﻿using Dapper;
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

        public IEnumerable<Category> GetCategory(int? id, int? typeId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @$"SELECT {(id!=null?"TOP 1":"")} * FROM dbo.Category c
                    left join TypeTransaction tt on tt.Id = c.TypeId
                    Where 1=1 
                    {(id != null ? $"AND c.Id ={id} " : "AND c.CategoryId IS NULL")}
                    {(typeId != null ? $"AND c.TypeId ={typeId} " : "")}
                    order by c.Name";
                return db.Query<Category, TypeTransactionModel, Category>(
                    sql,
                    (c, tt) =>
                    {
                        c.Type = tt;
                        using (IDbConnection db = new SqlConnection(connectionString))
                        {
                            c.SubCategory = db.Query<SubCategoryModel>(
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
