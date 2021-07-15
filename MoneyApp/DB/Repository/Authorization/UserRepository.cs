using Dapper;
using Microsoft.Data.SqlClient;
using MoneyApp.DB.Interface.Repository.Authorization;
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

        public UserModel GetUser(string login)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @$"SELECT TOP 1  * FROM dbo.[User] u
                                Where u.login = '{login}'";
                return db.Query<UserModel>(sql).FirstOrDefault();
            }
        }

        public UserModel GetUser(string login, string password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = @$"SELECT TOP 1  * FROM dbo.[User] u
                                Where u.login = '{login}'
                                AND u.password = '{password}'";
                return db.Query<UserModel>(sql).FirstOrDefault();
            }
        }
    }
}