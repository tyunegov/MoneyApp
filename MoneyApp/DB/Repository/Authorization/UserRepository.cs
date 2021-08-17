using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.DB.Interface.Authorization;
using MoneyApp.Models.User;
using MoneyApp.Repository;
using System.Data;
using System.Linq;

namespace MoneyApp.DB.Repository.Authorization
{
    public class UserRepository : IUserRepository
    {
        private string connectionString;

        public UserRepository()
        {
            this.connectionString = DBHelper.CONNECTION_STRING;
        }

        public UserModel Get(int userId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @$"SELECT TOP 1  * FROM dbo.[User] u
                                Where u.id = '{userId}'";
                var v = db.Query<UserModel>(sql).FirstOrDefault();
                return v;
            }
        }

        public UserModel Get(string login)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @$"SELECT TOP 1  * FROM dbo.[User] u
                                Where u.login = '{login}'";
                return db.Query<UserModel>(sql).FirstOrDefault();
            }
        }

        public UserModel Get(string login, string password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @$"SELECT TOP 1  * FROM dbo.[User] u
                                Where u.login = '{login}'
                                AND u.password = '{password}'";
                var v = db.Query<UserModel>(sql).FirstOrDefault();
                return v;
            }
        }

        public int? Insert(UserModel user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = $@"DECLARE @ID int;
                               INSERT INTO dbo.[User] (login, password, role)
                                    VALUES('{user.Login}',
                                    '{user.Password}',
                                    '{user.Role}');
                                     SET @ID = SCOPE_IDENTITY();
                                     SELECT id from dbo.[User]
							         where id = @ID";
                return db.Query<int?>(sqlQuery).FirstOrDefault();
            }
        }
    }
}